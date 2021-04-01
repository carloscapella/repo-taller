using Api_NetCore_Example.Entities;

namespace Api_NetCore_Example.Models
{
    public class CustomerModel
    {
        public CustomerModel()
        {

        }

        public CustomerModel(Customer customerEntity)
        {
            Id = customerEntity.Id.ToString();
            FirstName = customerEntity.Name;
            LastName = customerEntity.Surename;
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
