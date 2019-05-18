import { Customer } from '../models/customer.model';

export interface IAppState {
    customer: Customer[];
    filteredCustomer: Customer[];
}
