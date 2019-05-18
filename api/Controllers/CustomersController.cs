using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerInfo.Models;
using CustomerInfo.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInfo.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private CustomerService customerService;

        public CustomersController(CustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return customerService.GetAll();
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(Guid id)
        {
            var customer = customerService.GetById(id);

            if(customer == null) return NotFound();
            return customer;
        }

        // POST api/customers
        // [HttpPost]
        // public void Post([FromBody] Customer value)
        // {
        // }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(Guid id, [FromBody] Customer value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                
            }

            return customerService.Update(id, value);
        }

        // DELETE api/customers/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
