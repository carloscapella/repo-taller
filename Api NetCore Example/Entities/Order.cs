using System;
using System.Collections.Generic;

namespace Api_NetCore_Example.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        
        public bool Active { get; set; }
        public double TotalAmount { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CustomerId{ get; set; }
        public Customer Customer { get; set; }
    }
}
