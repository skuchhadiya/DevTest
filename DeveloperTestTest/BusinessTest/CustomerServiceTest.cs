using DeveloperTest.Business;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Enums;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace DeveloperTestTest
{
    [TestClass]
    public class CustomerServiceTest
    {
        private ApplicationDbContext context;

        public CustomerServiceTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ServiceSightDevTest")
                .Options;

            this.context = new ApplicationDbContext(options);
            Seed(context);
        }

        [TestMethod]
        public void GetCustomersAsync()
        {
            

            var service = new CustomerService(this.context);

            var expectObject = new CustomerModel[]
            {
                new CustomerModel(){CustomerId = 1, Name = "Sanjay", Type = CustomerType.Small },
                new CustomerModel(){CustomerId = 2, Name = "Krishna", Type = CustomerType.Large}
            };
            var expect = JsonConvert.SerializeObject(expectObject);

            var resultObject = service.GetCustomersAsync().Result;
            var result = JsonConvert.SerializeObject(resultObject);

            Assert.AreEqual(expect, result);
            this.context.Dispose();

        }

        [TestMethod]
        public void GetCustomerAsync()
        {


            var service = new CustomerService(this.context);

            var expectObject= new CustomerModel() { CustomerId = 1, Name = "Sanjay", Type = CustomerType.Small };
            var expect = JsonConvert.SerializeObject(expectObject);
            
            var resultObject = service.GetCustomerAsync(1).Result;
            var result = JsonConvert.SerializeObject(resultObject);

            Assert.AreEqual(expect, result);
            this.context.Dispose();

        }

        [TestMethod]
        public void CreateCustomerAsync()
        {
            var service = new CustomerService(this.context);
            var newCustomer = new CustomerModel() { CustomerId = 0, Name = "Xyz", Type = CustomerType.Small };
            
            var resultObject = service.CreateCustomerAsync(newCustomer).Result;
            
            Assert.AreNotEqual(newCustomer.CustomerId, resultObject.CustomerId);
            Assert.AreEqual(newCustomer.Name, resultObject.Name);
            Assert.AreEqual(newCustomer.Type, resultObject.Type);
            this.context.Dispose();


        }
        private void Seed(ApplicationDbContext context)
        {
            var customers = new Customer[]
            {

                    new Customer() {CustomerId = 1, Name = "Sanjay", Type = CustomerType.Small },
                    new Customer() { CustomerId = 2, Name = "Krishna", Type = CustomerType.Large }

            };
            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}
