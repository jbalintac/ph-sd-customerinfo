import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { CustomerRoutingModule } from './customer.routing';
import { CustomerComponent } from './pages/customer.component';
import { CustomerDetailComponent } from './pages/customer-detail/customer-detail.component';
import { CustomerListComponent } from './pages/customer-list/customer-list.component';

import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faSortAlphaDown, faSortAlphaUp, faPlus, faTrash } from '@fortawesome/free-solid-svg-icons';


@NgModule({
  declarations: [
    CustomerComponent,
    CustomerDetailComponent,
    CustomerListComponent
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    FontAwesomeModule
  ]
})
export class CustomerModule {
  constructor() {
    library.add(faSortAlphaDown, faSortAlphaUp, faPlus, faTrash);
  }
}
