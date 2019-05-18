import { CustomerStatus } from './customer.model';

export class SearchQuery {

    constructor(
        public term: string,
        public customerStatus: CustomerStatus,
        public sortDirection: SortDirection) {
    }
}


export enum SortDirection {
    Ascending,
    Descending,
}
