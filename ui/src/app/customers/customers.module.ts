import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';
import { CustomerRoutingModule } from './customers-routing.module';
import { CustomerService } from '../services/customer.service';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    CustomerListComponent,
    CustomerDetailComponent
  ],
  imports: [
    CommonModule,
    FormsModule,

    //CustomerRoutingModule for providing lazy loading support 
    CustomerRoutingModule
  ]
})
export class CustomersModule { }
