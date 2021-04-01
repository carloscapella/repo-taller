using Api_NetCore_Example.Entities;
using Api_NetCore_Example.Models;
using System.Collections.Generic;

namespace Api_NetCore_Example.Repositories
{
    public interface ICustomerRepository
    {
        public List<CustomerModel> GetAll();
        public Customer Find(string customerId);
        public void Delete(CustomerModel customer);
        public Customer Update(string customerId, CustomerUpdateCmd command);
        public CustomerModel Create(CustomerCreateCmd command);
    }
}
