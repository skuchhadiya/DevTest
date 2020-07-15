import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICustomerModel } from '../models/customer.model';
import { environment } from '../../environments/environment';
import { IEnvironment } from 'src/environments/IEnvironment';

@Injectable({
  providedIn: 'root'
})

export class CustomerService {

  private _rootUrl: string;

  constructor(private httpClient: HttpClient) {
    const environmentVariable = <IEnvironment>environment;
    this._rootUrl = environmentVariable.apiEndPoint
  }

  public GetCustomers(): Observable<ICustomerModel[]> {

    return this.httpClient.get<ICustomerModel[]>(this._rootUrl + 'Customer');

  }

  public GetCustomer(customerId: number): Observable<ICustomerModel> {

    return this.httpClient.get<ICustomerModel>(this._rootUrl + 'Customer/' + customerId);

  }

  public CreateCustomer(customer: ICustomerModel): Observable<ICustomerModel> {

    return this.httpClient.post<ICustomerModel>(this._rootUrl + 'Customer', customer);

  }
}
