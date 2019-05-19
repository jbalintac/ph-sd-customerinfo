import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Subject } from 'rxjs';
import { FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { CustomerService, NoteService, Customer, CustomerStatus, Note } from 'src/app/core';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.scss'],
})
export class CustomerDetailComponent implements OnInit {
  customer: Customer;
  customerStatuses: string[];
  customerStatusField = new FormControl();
  noteKeyUp = new Subject<Note>();
  isLoading = false;

  constructor(
    private route: ActivatedRoute,
    private customerService: CustomerService,
    private noteService: NoteService
  ) { }

  ngOnInit() {
    this.route.data.subscribe(d => this.customer = d.customer);

    this.customerStatuses = this.ToArray(CustomerStatus);
    this.customerStatusField.setValue(this.customer.status);

    this.subscribeToForms();
  }

  subscribeToForms() {
    this.customerStatusField.valueChanges.pipe(
      debounceTime(400),
      distinctUntilChanged()
    ).
    subscribe(customerStatus => {
      this.customerService
        .updateCustomer({...this.customer, status: customerStatus })
        .subscribe(c => this.customer = c);
    });

    this.noteKeyUp
      .pipe(
        debounceTime(400),
        /* TODO: distinctUntilChanged()*/)
      .subscribe((data) => {
        this.updateNote(data);
      });
  }

  addNote() {
    this.isLoading = true;
    this.noteService.addNote(
        new Note('00000000-0000-0000-0000-000000000000', this.customer.id, '')
      ).subscribe(n => {
        this.customerService.getSingle(this.customer.id).subscribe(c => this.customer = c);
        this.isLoading = false;
    });
  }

  updateNote(note: Note) {
    this.isLoading = true;
    this.noteService.updateNote(note)
      .subscribe(n => {
        // this.customerService.getSingle(this.customer.id).subscribe(c => this.customer = c);
        this.isLoading = false;
    });
  }

  removeNote(note: Note) {
    this.isLoading = true;
    this.noteService.deleteNote(note.id)
      .subscribe(n => {
        this.customerService.getSingle(this.customer.id).subscribe(c => this.customer = c);
        this.isLoading = false;
    });
  }

  // TODO: Move to core utilities
  // Helper
  ToArray(enumme) {
    return Object.keys(enumme)
        .map(key => enumme[key]);
  }
}
