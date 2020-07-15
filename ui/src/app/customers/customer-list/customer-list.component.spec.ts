import { CustomerListComponent } from './customer-list.component';
import { CustomerService } from 'src/app/services/customer.service';
import { HttpClient } from '@angular/common/http';


describe('CustomerListComponent', () => {
  let component: CustomerListComponent;

  it('should create CustomerListComponent', () => {
    const service = new CustomerService({} as HttpClient);
    component = new CustomerListComponent(service);
    expect(component).toBeTruthy();
  });
});