import { Component } from '@angular/core';
import { ICustomerModel } from 'src/app/models/customer.model';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from 'src/app/services/customer.service';
import { CustomerType } from 'src/app/enums/customer-type';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.scss']
})

export class CustomerDetailComponent {

  private _customerId: number;

  public customer: ICustomerModel;
  public customerTypes = CustomerType;

  constructor(
    private _route: ActivatedRoute,
    private _customerService: CustomerService) {
    this._customerId = parseInt(_route.snapshot.params.id);
    this._customerService.GetCustomer(this._customerId).subscribe(cust => this.customer = cust);
  }

}
