using DeveloperTest.Models;
using System.Threading.Tasks;

namespace DeveloperTest.Business
{
    public interface ICustomerService
    {
        Task <CustomerModel> CreateCustomerAsync(CustomerModel model);
        Task <CustomerModel> GetCustomerAsync(int CustomerId);
        Task<CustomerModel[]> GetCustomersAsync();
    }
}