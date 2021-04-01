using System;

namespace Api_NetCore_Example.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
