import { Customer } from '../models/customer.model';
import { SearchQuery } from '../models/search-query.model';
export const FILTER_CUSTOMER = 'customer/FILTER';
export const REQUEST_CUSTOMER_SUCCESS = 'customer/REQUEST_CUSTOMER_SUCCESS';


export function filterCustomer(searchQuery: SearchQuery) {
    return {
        type: FILTER_CUSTOMER,
        searchQuery
    };
}

export function storeCustomer(customer: Customer[]) {
    return {
        type: REQUEST_CUSTOMER_SUCCESS,
        customer
    };
}
