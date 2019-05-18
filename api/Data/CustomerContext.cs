using CustomerInfo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerInfo.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var customers = new Customer[3] {
                new Customer() { 
                    Id = Guid.NewGuid(),
                    Status = CustomerStatus.Prospective,
                    CreatedDate = new DateTime(2019,02,22),
                    Name = "Magenic Manila, Inc.",
                    Contact = "+63 (2) 222-2123",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
                },
                new Customer() { 
                    Id = Guid.NewGuid(),
                    Status = CustomerStatus.NonActive,
                    CreatedDate = new DateTime(2017,05,12),
                    Name = "Graycorp, Pty Ltd",
                    Contact = "+63 (8) 217-6582",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
                },
                new Customer() { 
                    Id = Guid.NewGuid(),
                    Status = CustomerStatus.Current,
                    CreatedDate = new DateTime(2015,10,05),
                    Name = "Misys Philippines",
                    Contact = "+63 (2) 673-9212",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
                }
            };
            
            var customerNotes = new Note[4] {
                new Note() { 
                    CustomerId = customers[0].Id, 
                    Id = Guid.NewGuid(),
                    Value = "Recognized as Consultant of the Quarter on 2018Q4"
                },
                new Note() { 
                    CustomerId = customers[0].Id, 
                    Id = Guid.NewGuid(),
                    Value = "Worked here for over 2 years for 3 projects"
                },
                new Note() { 
                    CustomerId = customers[0].Id, 
                    Id = Guid.NewGuid(),
                    Value = "PWA app with offline sync, QA testing for ETL, WebApp for insurance company"
                },
                new Note() { 
                    CustomerId = customers[2].Id, 
                    Id = Guid.NewGuid(),
                    Value = "Used WebSphere and Banking Swift protocol"
                }
            };

            modelBuilder.Entity<Customer>().HasData(customers);
            modelBuilder.Entity<Note>().HasData(customerNotes);
        }
    }
}