

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CustomerInfo.Models;

namespace CustomerInfo.Models
{
    public enum CustomerStatus {
        Prospective = 0,
        Current,
        NonActive,
    }

    public class Customer
    {
        public Guid Id { get; set; }
        [EnumDataType(typeof(CustomerStatus))]  
        public CustomerStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }
        public List<Note> Notes { get; set; }
    }
}