import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

import { Customer } from '../models/customer.model';
import { environment } from '../../../environments/environment';
import { SearchQuery } from '../models/search-query.model';


@Injectable({ providedIn: 'root'})
export class CustomerService {

  private customerUrl = environment.customerApiUrl;

  constructor(private http: HttpClient) {}


    getAll(): Observable<Customer[]> {
        return this.http.get<Customer[]>(this.customerUrl);
    }

    getSingle(id: string): Observable<Customer> {
        return this.http.get<Customer[]>(this.customerUrl).pipe(map((response) =>
        response.filter(m => m.id === id)[0] as Customer));
    }

    updateCustomer(customer: Customer): Observable<Customer> {
        return this.http.put<Customer>(`${this.customerUrl}/${customer.id}`, customer);
    }

    // search(query: SearchQuery): Observable<Customer[]> {
    //     return this.http.get(this.customerUrl).pipe(map((response) =>
    //         <Customer[]>response.json().filter(m => {

    //             return  (query.genreType == null ||
    //              query.genreType.toString() === '' ||
    //              m.genres.includes(query.genreType)) && (
    //                 query.term == null ||
    //                 m.name.toUpperCase().includes(query.term.toUpperCase())
    //                 || m.description.toUpperCase().includes(query.term.toUpperCase()));
    //         })));
    // }
}
