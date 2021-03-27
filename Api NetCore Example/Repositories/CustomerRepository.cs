using Api_NetCore_Example.Mappers;
using Api_NetCore_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api_NetCore_Example.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> _customerList;

        public CustomerRepository()
        {
            _customerList = new List<Customer>
            {
                new Customer { Id = "1", FirstName = "Carlos", LastName = "Capella" },
                new Customer { Id = "2", FirstName = "Luis", LastName = "Suarez" },
                new Customer { Id = "3", FirstName = "pepe", LastName = "Lopez" }
            };
        }

        public List<Customer> GetAll()
        {
            return _customerList;
        }

        public Customer Find(string customerId)
        {
            var customer = _customerList.FirstOrDefault(x => x.Id.Equals(customerId));

            return customer;
        }

        public void Delete(Customer customer)
        {
            _customerList.Remove(customer);
        }

        public Customer Update(string customerId, CustomerUpdateCmd command)
        {
            // 1 buscamos al elemento en la lista
            var customerInDataBase = Find(customerId);

            customerInDataBase.FirstName = command.FirstName;
            customerInDataBase.LastName = command.LastName;

            return customerInDataBase;
        }

        public Customer Create(CustomerCreateCmd command)
        {
            var newCustomer = CustomerMapper.FromCustomerCreateCmd(command);

            _customerList.Add(newCustomer);

            return newCustomer;

        }
    }
}
