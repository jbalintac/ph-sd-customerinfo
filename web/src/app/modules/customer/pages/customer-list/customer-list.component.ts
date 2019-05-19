import { Component, OnInit, Input } from '@angular/core';
import { Customer } from '../../../../core';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss']
})
export class CustomerListComponent implements OnInit {

  @Input() customer: Customer;
  constructor() { }

  ngOnInit() {
  }

}
