import { Component, OnInit } from '@angular/core';
import { CustomerService } from 'src/app/services/customer.service';
import { CustomerType } from 'src/app/enums/customer-type';
import { ICustomerModel } from 'src/app/models/customer.model';
import { NgForm, FormGroup, FormControl, Validators } from '@angular/forms';
@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss']
})
export class CustomerListComponent implements OnInit {
  customerTypes = CustomerType;
  customers: ICustomerModel[];

  public newJCustomer: ICustomerModel = {
    customerId: 0,
    name: null,
    type: null
  };

  // Could create form like this will easy for testing and handling we could crete own our validator 
  // form: FormGroup = new FormGroup ({
  //   customerId: new FormControl(0),
  //   name: new FormControl('', [Validators.required, Validators.maxLength(5)]),
  //   type: new FormControl(null, [Validators.required])
  // })

  constructor(private _customerService: CustomerService) { }

  ngOnInit() {
    this._customerService.GetCustomers().subscribe(customers => this.customers = customers)
  }

  createCustomer(form: NgForm) {

    if (form.invalid) {
      alert('form is not valid');
    } else {
      //here we solve the problem to re call all customers api again by pushing new customer in exsting list
      //oter wise can use async pipe
      this._customerService.CreateCustomer(this.newJCustomer).subscribe(newCustomer => this.customers.push(newCustomer));
    }
  }

}
