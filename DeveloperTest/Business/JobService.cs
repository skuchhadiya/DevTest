using System.Linq;
using System.Threading.Tasks;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext context;

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<JobModel[]> GetJobs()
        {
            var data = await context.Jobs.Include("Customer").ToArrayAsync();

            return data.Select(x => this.GetJobDTO(x)).ToArray();
        }

        public async Task<JobModel>  GetJob(int jobId)
        {
            var data = await context.Jobs.Where(x => x.JobId == jobId).Include("Customer").SingleOrDefaultAsync();
            return this.GetJobDTO(data);
        }

        public async Task<JobModel> CreateJob(BaseJobModel model)
        {
            var customer = await context.Customers.Where(x => x.CustomerId == model.Customer.CustomerId).SingleOrDefaultAsync();
            var addedJob = context.Jobs.Add(new Job
            {
                Engineer = model.Engineer,
                When = model.When,
                Customer = customer

            });

            await context.SaveChangesAsync();

            return this.GetJobDTO(addedJob.Entity);
        }

        private JobModel GetJobDTO(Job job)
        {
            return new JobModel()
            {
                JobId = job.JobId,
                Engineer = job.Engineer,
                When = job.When,
                Customer = job.Customer!=null ? this.GetCustomerDTO(job.Customer) :null
            };
        }

        private CustomerModel GetCustomerDTO(Customer customer)
        {
            return new CustomerModel()
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Type = customer.Type
            };
        }
    }
}
