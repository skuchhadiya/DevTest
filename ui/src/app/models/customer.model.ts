import { CustomerType } from '../enums/customer-type';

export interface ICustomerModel {
    customerId: number;
    name: string;
    type: CustomerType
}
