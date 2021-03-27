using Api_NetCore_Example.Models;
using System.Collections.Generic;

namespace Api_NetCore_Example.Services
{
    public interface ICustomerService
    {
        public List<Customer> GetAll();
        public Customer Find(string customerId);
        public Customer Create(CustomerCreateCmd command);
        public Customer Update(string customerId, CustomerUpdateCmd command);
        public Customer Delete(string customerId);
    }
}
