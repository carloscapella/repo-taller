using System;

namespace Api_NetCore_Example.Entities
{
    public class CustomerPhones
    {
        public Guid Id
        {
            get; set;
        }

        public string Phone { get; set; }

        public Guid CustomerId
        {
            get; set;
        }

        public Customer Customer
        {
            get; set;
        }
    }
}
