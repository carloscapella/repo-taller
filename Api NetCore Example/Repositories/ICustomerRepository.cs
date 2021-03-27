using Api_NetCore_Example.Models;
using System.Collections.Generic;

namespace Api_NetCore_Example.Repositories
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAll();
        public Customer Find(string customerId);
        public void Delete(Customer customer);
        public Customer Update(string customerId, CustomerUpdateCmd command);
        public Customer Create(CustomerCreateCmd command);
    }
}
