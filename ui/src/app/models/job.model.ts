import { ICustomerModel } from './customer.model';

export interface JobModel {
  jobId: number;
  engineer: string;
  when: Date;
  customer: ICustomerModel;
}
