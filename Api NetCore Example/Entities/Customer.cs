using System;
using System.Collections.Generic;

namespace Api_NetCore_Example.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public ICollection<CustomerPhones> Phones { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
