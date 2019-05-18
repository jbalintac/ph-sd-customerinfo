using System;
using System.Collections.Generic;
using System.Linq;
using CustomerInfo.Data;
using CustomerInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerInfo.Services
{
    public class CustomerService
    {
        private CustomerContext customerContext;

        public CustomerService(CustomerContext customerContext)
        {
            this.customerContext = customerContext;
        }

        public List<Customer> GetAll() 
        {
            return customerContext.Set<Customer>().Include(c => c.Notes).ToList();
        }

        public Customer GetById(Guid id)
        {
            return customerContext.Set<Customer>().Include(c => c.Notes).SingleOrDefault(c => c.Id == id);
        }

        public Customer Update(Guid id, Customer customer)
        {
            var customerData = customerContext.Set<Customer>().Include(c => c.Notes).SingleOrDefault(c => c.Id == id);

            if(customerData != null) 
            {
                // TODO: Validate the correct enum values here too aside from Controller level
                customerData.Status = customer.Status;
                customerData.Name = customer.Name;
                customerData.Description = customer.Description;
                customerData.Contact = customer.Contact;

                customerContext.Update(customerData);
                customerContext.SaveChanges();
            }

            return customerData;
        }
    }
}
