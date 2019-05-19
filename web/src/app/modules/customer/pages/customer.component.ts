
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { debounceTime, map, distinctUntilChanged } from 'rxjs/operators';

import { store, filterCustomer, storeCustomer,
  CustomerService, Customer, CustomerStatus,
  SearchQuery,  SortDirection } from 'src/app/core';


@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  searchField = new FormControl();
  customerStatusField = new FormControl();

  customers: Customer[];
  customerStatuses: string[];

  readonly ascSortIcon = ['fas', 'sort-alpha-down'];
  readonly descSortIcon = ['fas', 'sort-alpha-up'];

  sortDirection = SortDirection.Ascending;
  sortIcon = this.ascSortIcon;

  constructor(
    private customerService: CustomerService) { }

  ngOnInit() {

    this.initRedux();

    this.loadCustomer();
    this.subscribeToForms();

    this.customerStatuses = this.ToArray(CustomerStatus);
    this.customerStatuses.unshift('');
  }

  initRedux() {
    store.subscribe(() => {
      this.updateFromState();
    });
  }

  subscribeToForms() {

    // Term
    this.searchField.valueChanges.pipe(
      debounceTime(400),
      distinctUntilChanged()
    ).
    subscribe(term => {
      store.dispatch(filterCustomer(new SearchQuery(term, this.customerStatusField.value, this.sortDirection)));
    });

    // Status
    this.customerStatusField.valueChanges.pipe(
      debounceTime(400),
      distinctUntilChanged()
    ).
    subscribe(customerStatus => {
       store.dispatch(filterCustomer(new SearchQuery(this.searchField.value, customerStatus, this.sortDirection)));
    });
  }

  loadCustomer() {
    this.customerService.getAll().subscribe(m => store.dispatch(storeCustomer(m)));
  }

  updateFromState() {
    const allState = store.getState();
    this.customers = allState.filteredCustomer;
  }

  sortCustomer() {

    this.sortDirection =
      this.sortDirection === SortDirection.Ascending ?
      SortDirection.Descending : SortDirection.Ascending;

    this.sortIcon =
      this.sortDirection === SortDirection.Ascending ?
      this.ascSortIcon : this.descSortIcon;

    store.dispatch(filterCustomer(new SearchQuery(this.searchField.value, this.customerStatusField.value, this.sortDirection)));
  }

  // TODO: Move to core utilities
  // Helper
  ToArray(enumme) {
    return Object.keys(enumme)
        .map(key => enumme[key]);
  }
}
