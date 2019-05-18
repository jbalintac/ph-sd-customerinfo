import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerResolver } from './customer-resolver.service';
import { CustomerComponent } from './pages/customer.component';
import { CustomerDetailComponent } from './pages/customer-detail/customer-detail.component';

export const routes: Routes = [
    {
      path: '',
      children: [
        {
          path: '',
          component: CustomerComponent, data: { state: 'customer'}
        },
        {
          path: 'customer/:id',
          component: CustomerDetailComponent,
          resolve: {
             customer: CustomerResolver
          }, data: { state: 'movie'}
        }
      ]
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class CustomerRoutingModule { }
