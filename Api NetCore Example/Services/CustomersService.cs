using Api_NetCore_Example.Models;
using Api_NetCore_Example.Models.Exceptions;
using Api_NetCore_Example.Models.Validations;
using Api_NetCore_Example.Repositories;
using System.Collections.Generic;

namespace Api_NetCore_Example.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;


        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer Find(string customerId)
        {
            return _customerRepository.Find(customerId);
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer Create(CustomerCreateCmd command)
        {
            // 1. validar
            var customer = _customerRepository.Find(command.Id);

            var isCustomerRepeated = customer != null;

            var validor = new CustomerCreateCmdValidator(isCustomerRepeated);

            var validationResult = validor.Validate(command);

            // 2. si falla alguna validacion, retornar los errores respectivos

            if (!validationResult.IsValid)
            {
                // retornamos los mensajes de error
                List<Validation> errorList = new List<Validation>();

                foreach (var error in validationResult.Errors)
                {
                    errorList.Add(new Validation { Name = error.PropertyName, Message = error.ErrorMessage });
                }

                throw new GenericValidationException(errorList);
            }



            // codigo taller pasado
            

            if (customer != null)
            {
                throw new DuplicatedPrimaryKeyException();
            }

            // 3. en caso contrario, guardar
            return _customerRepository.Create(command);
        }

        public Customer Update(string customerId, CustomerUpdateCmd command)
        {
            var customer = _customerRepository.Find(customerId);

            if (customer == null)
            {
                throw new NotFoundException();
            }

            return _customerRepository.Update(customerId, command);
        }

        public Customer Delete(string customerId)
        {
            var customer = _customerRepository.Find(customerId);

            if (customer == null)
            {
                throw new NotFoundException();
            }

            _customerRepository.Delete(customer);

            return customer;
        }
    }
}
