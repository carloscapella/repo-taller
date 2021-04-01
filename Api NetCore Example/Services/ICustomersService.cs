using Api_NetCore_Example.Models;
using System.Collections.Generic;

namespace Api_NetCore_Example.Services
{
    public interface ICustomerService
    {
        public List<CustomerModel> GetAll();
        public CustomerModel Find(string customerId);
        public CustomerModel Create(CustomerCreateCmd command);
        public CustomerModel Update(string customerId, CustomerUpdateCmd command);
        public CustomerModel Delete(string customerId);
    }
}
