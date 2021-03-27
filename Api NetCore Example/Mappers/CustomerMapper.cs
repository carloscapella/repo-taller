using Api_NetCore_Example.Models;

namespace Api_NetCore_Example.Mappers
{
    public static class CustomerMapper
    {
        public static Customer FromCustomerCreateCmd(CustomerCreateCmd command)
        {
            Customer newCustomer = new Customer();

            newCustomer.Id = command.Id;
            newCustomer.FirstName = command.FirstName;
            newCustomer.LastName = command.LastName;

            return newCustomer;

        }
    }
}
