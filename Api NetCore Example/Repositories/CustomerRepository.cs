using Api_NetCore_Example.Database;
using Api_NetCore_Example.Entities;
using Api_NetCore_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api_NetCore_Example.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        //private List<CustomerModel> _customerList;

        private TallerDbContext _tallerDbContext;

        public CustomerRepository()
        {

        }


        public CustomerRepository(TallerDbContext tallerDbContext)
        {
            _tallerDbContext = tallerDbContext;
        }

        public List<CustomerModel> GetAll()
        {
            var entityList = _tallerDbContext.Customers.ToList();

            var modelList = new List<CustomerModel>();
            
            foreach (var item in entityList)
            {
                modelList.Add(new CustomerModel(item));
            }

            return modelList;            
        }

        public Customer Find(string customerId)
        {
            Guid customerIdCasted = Guid.Parse(customerId);

            return _tallerDbContext.Customers.FirstOrDefault(x => x.Id.Equals(customerIdCasted));
            
        }

        public void Delete(CustomerModel customer)
        {
            //_customerList.Remove(customer);
        }

        public Customer Update(string customerId, CustomerUpdateCmd command)
        {
            // 1 buscamos al elemento en la lista
            var customerEntity = Find(customerId);
          
            customerEntity.Name = command.FirstName;
            customerEntity.Surename = command.LastName;

            _tallerDbContext.SaveChanges();

            return customerEntity;
        }

        public CustomerModel Create(CustomerCreateCmd command)
        {
            //var newCustomer = CustomerMapper.FromCustomerCreateCmd(command);

            //_customerList.Add(newCustomer);
            //_tallerDbContext.Customers.Add(asdasdas);
            //_tallerDbContext.SaveChanges();
            return null; //newCustomer;

        }
    }
}
