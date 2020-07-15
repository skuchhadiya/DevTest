using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;

        public CustomerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<CustomerModel[]> GetCustomersAsync()
        {
            var result  = await context.Customers.ToArrayAsync();
            return result.Select(x => this.GetCustomerDTO(x)).ToArray();
        }

        public async Task <CustomerModel> GetCustomerAsync(int CustomerId)
        {
            var result = await context.Customers.Where(x => x.CustomerId == CustomerId).SingleOrDefaultAsync();
            return this.GetCustomerDTO(result);
        }

        public async  Task <CustomerModel> CreateCustomerAsync(CustomerModel model)
        {
            var addedCustomers = context.Customers.Add(new Customer()
            {
                Name = model.Name,
                Type = model.Type
            });

            await context.SaveChangesAsync();
            return this.GetCustomerDTO(addedCustomers.Entity);

        }

        //Good to Create DTO Object not to send memory reference 
        private CustomerModel GetCustomerDTO(Customer customer)
        {
            //repeating code
            return new CustomerModel
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Type = customer.Type
            };
        }
    }
}
