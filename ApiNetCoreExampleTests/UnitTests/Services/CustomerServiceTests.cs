using Api_NetCore_Example.Models;
using Api_NetCore_Example.Models.Exceptions;
using Api_NetCore_Example.Repositories;
using Api_NetCore_Example.Services;
using Moq;
using Xunit;

namespace ApiNetCoreExampleTests.UnitTests.Services
{
    public class CustomerServiceTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private CustomerService _customerService { get; set; }

        public CustomerServiceTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();

            _customerService = new CustomerService(_customerRepositoryMock.Object);
        }

        [Fact]
        public void ServiceCreateShouldReturnSuccess()
        {
            CustomerCreateCmd command = new CustomerCreateCmd
            {
                Id = "123",
                FirstName = "test",
                LastName = "otro"
            };

            CustomerModel nullCustomer = null;

            _customerRepositoryMock.Setup(x => x.Find(It.IsAny<string>())).Returns(nullCustomer);

            _customerRepositoryMock.Setup(x => x.Create(It.IsAny<CustomerCreateCmd>())).Returns(new CustomerModel());

            var createdUser = _customerService.Create(command);

            Assert.NotNull(createdUser);
        }

        // bug: 4587
        [Fact]
        public void ServiceCreateShouldThrowGenericValidationException()
        {
            CustomerCreateCmd command = new CustomerCreateCmd
            {
                Id = "3453453453454534",
                FirstName = "",
                LastName = "Pedro"
            };

            CustomerModel nullCustomer = null;

            _customerRepositoryMock.Setup(x => x.Find(It.IsAny<string>())).Returns(nullCustomer);

            var ex = Assert.Throws<GenericValidationException>(() => _customerService.Create(command));

            Assert.NotNull(ex);
        }
    }
}
