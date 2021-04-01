using Api_NetCore_Example.Models;

namespace Api_NetCore_Example.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerModel FromCustomerCreateCmd(CustomerCreateCmd command)
        {
            CustomerModel newCustomer = new CustomerModel();

            newCustomer.Id = command.Id;
            newCustomer.FirstName = command.FirstName;
            newCustomer.LastName = command.LastName;

            return newCustomer;

        }
    }
}
