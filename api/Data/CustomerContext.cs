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
            var customers = new Customer[8] {
                new Customer() { 
                    Id = Guid.NewGuid(),
                    Status = CustomerStatus.Current,
                    CreatedDate = new DateTime(2019,06,05),
                    Name = "Propellerhead.",
                    Contact = "+64 9 309 6595; info@propellerhead.co.nz",
                    Description = "We are dedicated to the powerful ideas that make the world a better place for our clients, their users, and our community. We have delivered a broad range of solutions from identity management, to sophisticated web platforms, to high volume IoT integration solutions. We are chosen primarily on the basis of our abilities as a creative problem solver."
                },
                new Customer() { 
                    Id = Guid.NewGuid(),
                    Status = CustomerStatus.Prospective,
                    CreatedDate = new DateTime(2019,03,04),
                    Name = "Innoscripta GmbH",
                    Contact = "+49 (0)89 4625 8551",
                    Description = "innoscripta ist ein stark wachsendes Unternehmen im Bereich Technologietransfer, welches als Fördermittelspezialist für Forschungs- und Entwicklungsleistungen gilt und sich somit zur Nr. 1 im Bereich technische Innovationsberatung für mittelständische Unternehmen in Deutschland entwickelt hat. Die Kunden von innoscripta sind auf unterschiedlichsten Technologiefeldern tätig und gehören nicht selten zu den jeweiligen Branchenführern. Außerdem kooperiert innoscripta mit international angesehenen Universitäten."
                },
                new Customer() { 
                    Id = Guid.NewGuid(),
                    Status = CustomerStatus.Prospective,
                    CreatedDate = new DateTime(2018,11,12),
                    Name = "Kognity",
                    Contact = " info@kognity.com",
                    Description = "Founded in Sweden, Kognity was designed to redefine the traditional textbook and supercharge the learning process as we know it.It all began with two students who wanted to create the types of exciting and dynamic interactive learning resources they’d always wanted to experience in their own classrooms. Resolving to create a modern textbook to fulfil the needs of the modern learner, the result was Kognity."
                },
                new Customer() { 
                    Id = Guid.NewGuid(),
                    Status = CustomerStatus.Current,
                    CreatedDate = new DateTime(2017,04,03),
                    Name = "Magenic Manila, Inc.",
                    Contact = "+63 (02) 485 8400",
                    Description = "Helping Your Business MoveFast Forward. We’re Magenic. The digital technology consulting company built to get you to market faster. Our innovative digital product consulting team was created to help you get the best strategy and experience design to Fast Forward your product to market. Our rapid-fire process delivers the thinking you need to create superior digital products and get them to market faster. When you work with Magenic people, you work with best-in-class talent."
                },
                new Customer() { 
                    Id = Guid.NewGuid(),
                    Status = CustomerStatus.Prospective,
                    CreatedDate = new DateTime(2016,09,29),
                    Name = "Xero Limited",
                    Contact = "AUpress@xero.com",
                    Description = "We started Xero to change the game for small business. Our beautiful cloud-based accounting software connects people with the right numbers anytime, anywhere, on any device. For accountants and bookkeepers, Xero helps build a trusted relationship with small business clients through online collaboration. We’re proud to be helping over 1.8 million subscribers worldwide transform the way they do business. And we’re just getting started."
                },
                new Customer() { 
                    Id = Guid.NewGuid(),
                    Status = CustomerStatus.NonActive,
                    CreatedDate = new DateTime(2015,06,08),
                    Name = "Graycorp, Pty Ltd",
                    Contact = "+61 8 8127 5080; info@graycorp.com.au",
                    Description = "Graycorp is a South Australian owned and operated business that has been working with Australian small to medium sized companies since 1992. Building upon more than 20 years of software development experience, we offer solutions that meet the needs of Food & Beverage manufacturers and distributors who are confronted by the reality of high-volume, low-margin work. While each business is unique, there are common issues hounding today’s Food & Beverage entrepreneurs, including disparate systems, limited production control, large amounts of manual data entry, poor inventory control, and inability to trade online or electronically with their partners. The consequences are real and immediate and can have a profound impact on the profitability and ongoing viability of a business."
                },
                new Customer() { 
                    Id = Guid.NewGuid(),
                    Status = CustomerStatus.NonActive,
                    CreatedDate = new DateTime(2014,02,10),
                    Name = "Misys Philippines, Inc. (acquired by Finastra)",
                    Contact = "+63 (2) 479 9300",
                    Description = "Formed in 2017 by the combination of Misys and D+H, Finastra builds and deploys innovative, next-generation technology on our open Fusion software architecture and cloud ecosystem. Our scale and geographical reach means that we can serve customers effectively, regardless of their size or location—from global financial institutions to community banks and credit unions."
                },
                new Customer() { 
                    Id = Guid.NewGuid(),
                    Status = CustomerStatus.NonActive,
                    CreatedDate = new DateTime(2013,05,06),
                    Name = "Betsson Technologies, Inc. (office moved to Malta)",
                    Contact = "+356 2260 3300",
                    Description = "The Sportsbook Trading team provide odds on over 200,000 events per year. From Champions League Football to Trotting. From NBA playoffs to TV specials. The team consists of passionate, dedicated sports fans who work closely with the commercial, tech and product teams to ensure our customers have the best experience possible."
                }
            };
            
            var customerNotes = new Note[6] {
                new Note() { 
                    CustomerId = customers.FirstOrDefault(c => c.Name == "Propellerhead.").Id, 
                    Id = Guid.NewGuid(),
                    Value = "Application is currently at technical assignment stage."
                },
                new Note() { 
                    CustomerId = customers.FirstOrDefault(c => c.Name == "Innoscripta GmbH").Id, 
                    Id = Guid.NewGuid(),
                    Value = "Reach offer stage; Declined as we didn't reach agreement on terms."
                },
                new Note() { 
                    CustomerId = customers.FirstOrDefault(c => c.Name == "Magenic Manila, Inc.").Id, 
                    Id = Guid.NewGuid(),
                    Value = "Recognized as Consultant of the Quarter on 2018Q4."
                },
                new Note() { 
                    CustomerId = customers.FirstOrDefault(c => c.Name == "Magenic Manila, Inc.").Id, 
                    Id = Guid.NewGuid(),
                    Value = "Worked here for over 2 years for 3 projects: Keller LLC, Harbourvest LLC, ATI Physical."
                },
                new Note() { 
                    CustomerId = customers.FirstOrDefault(c => c.Name == "Magenic Manila, Inc.").Id, 
                    Id = Guid.NewGuid(),
                    Value = "PWA with offline syncing, Automated QA testing for ETL, WebApp for EDI processing."
                },
                new Note() { 
                    CustomerId = customers.FirstOrDefault(c => c.Name == "Misys Philippines, Inc. (acquired by Finastra)").Id, 
                    Id = Guid.NewGuid(),
                    Value = "Used WebSphere and Banking Swift protocol."
                }
            };

            modelBuilder.Entity<Customer>().HasData(customers);
            modelBuilder.Entity<Note>().HasData(customerNotes);
        }
    }
}