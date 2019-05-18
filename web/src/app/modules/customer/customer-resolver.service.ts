import { Injectable, } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { CustomerService, Customer } from 'src/app/core';

@Injectable({providedIn: 'root'})
export class CustomerResolver implements Resolve<Customer> {
  constructor(
    private customerService: CustomerService,
    private router: Router
  ) { }

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<any> {

  return this.customerService.getSingle(route.params.id)
            .pipe(catchError((err) =>   this.router.navigateByUrl('/')));
  }
}
