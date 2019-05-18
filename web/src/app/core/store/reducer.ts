import { IAppState } from './IAppState';
import { FILTER_CUSTOMER, REQUEST_CUSTOMER_SUCCESS } from './customer.action';
import { SortDirection } from '../models';

const customer = [];

const initialState: IAppState = {
  customer,
  filteredCustomer: customer
};

function filterCustomer(state, action): IAppState {

  const sorting =
    action.searchQuery.sortDirection === SortDirection.Ascending ?
    (a, b) => a.name.localeCompare(b.name) :  (a, b) => b.name.localeCompare(a.name);


  return Object.assign({}, state, {
    filteredCustomer: state.customer.filter(c => {

      return (action.searchQuery.term == null ||
              c.name.toUpperCase().includes(action.searchQuery.term.toUpperCase()) /*||
              c.description.toUpperCase().includes(action.searchQuery.term.toUpperCase())*/)

              && (action.searchQuery.customerStatus == null ||
              action.searchQuery.customerStatus.toString() === '' ||
              c.status.includes(action.searchQuery.customerStatus)) ;
    }).sort(sorting),
  });
}

function storeCustomer(state, action): IAppState {
  return Object.assign({}, state, {
    customer: action.customer,
    filteredCustomer: action.customer,
  });
}

export function reducer(state= initialState, action) {
    switch (action.type) {
      case FILTER_CUSTOMER:
        return filterCustomer(state, action);
      case REQUEST_CUSTOMER_SUCCESS:
        return storeCustomer(state, action);
      default:
        return state;
    }
}
