

using System;
using System.Collections.Generic;
using CustomerInfo.Models;

namespace CustomerInfo.Models
{

    public class Note
    {
        public Guid CustomerId { get; set; }
        public Guid Id { get; set; }
        public string Value { get; set; }
    }
}