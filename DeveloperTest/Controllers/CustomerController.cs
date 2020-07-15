using System.Threading.Tasks;
using DeveloperTest.Business;
using DeveloperTest.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeveloperTest.Controllers
{

    [ApiController, Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService customerService;
        public CustomerController(ICustomerService service)
        {
            this.customerService = service;
        }

        [HttpGet]
        public async Task <ActionResult> Get()
        {
            return Ok(await customerService.GetCustomersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await customerService.GetCustomerAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomerModel newCustomer)
        {
            return Ok(await customerService.CreateCustomerAsync(newCustomer));
        }

       
    }
}
