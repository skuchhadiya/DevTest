import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EngineerService } from '../services/engineer.service';
import { JobService } from '../services/job.service';
import { JobModel } from '../models/job.model';
import { Observable } from 'rxjs';
import { CustomerService } from '../services/customer.service';
import { ICustomerModel } from '../models/customer.model';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.scss']
})
export class JobComponent implements OnInit {

  engineers$: Observable<string[]>;
  customers$: Observable<ICustomerModel[]>;
  jobs: JobModel[] = [];

  public newJob: JobModel = {
    jobId: null,
    engineer: null,
    when: null,
    customer: null
  };

  constructor(
    private _engineerService: EngineerService,
    private _jobService: JobService,
    private _customerService: CustomerService) {

    this.customers$ = this._customerService.GetCustomers();
    this.engineers$ = this._engineerService.GetEngineers();
  }
  ngOnInit(): void {

    this._jobService.GetJobs().subscribe(jobs => this.jobs = jobs);
  }

  public createJob(form: NgForm): void {

    if (form.invalid) {
      alert('form is not valid');
    } else {
      this._jobService.CreateJob(this.newJob).then(() => {
        this._jobService.GetJobs().subscribe(jobs => this.jobs = jobs);
      });
    }

  }

}
