using System;
using System.Collections.Generic;

namespace Api_NetCore_Example.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<CustomerPhones> Phones
        {
            get; set;
        }
    }
}
