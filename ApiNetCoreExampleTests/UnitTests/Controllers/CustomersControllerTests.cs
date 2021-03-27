using Api_NetCore_Example.Controllers;
using Api_NetCore_Example.Models;
using Api_NetCore_Example.Models.Exceptions;
using Api_NetCore_Example.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ApiNetCoreExampleTests.UnitTests.Controllers
{
    public class CustomersControllerTests
    {
        private readonly Mock<ICustomerService> _customerService;
        protected readonly Mock<ILogger<CustomersController>> _logger;

        private CustomersController _customersController;

        public CustomersControllerTests()
        {
            _customerService = new Mock<ICustomerService>();
            _logger = new Mock<ILogger<CustomersController>>();

            _customersController = new CustomersController(
                _customerService.Object,
                _logger.Object);
        }

        private List<Customer> GetCustomerList()
        {
            return new List<Customer> { new Customer { Id = "1", FirstName = "Pepe", LastName = "Perez" } };            
        }

        #region GetAllCustomers tests

        [Fact]
        public void GetAllCustomersShouldReturnOk()
        {
            var data = GetCustomerList();

            _customerService.Setup(x => x.GetAll()).Returns(data);

            var response = _customersController.GetAllCustomers();

            var result = Assert.IsType<OkObjectResult>(response);

            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);

            var responseData = Assert.IsType<List<Customer>>(result.Value);

            Assert.NotEmpty(responseData);
        }


        [Fact]
        public void GetAllCustomersShouldReturnBadrequest()
        {
            _customerService.Setup(x => x.GetAll())
                .Throws(new Exception());

            var response = _customersController.GetAllCustomers();

            var result = Assert.IsType<BadRequestResult>(response);

            Assert.Equal(400, result.StatusCode);
        }

        #endregion

        #region CreateCustomer Tests

        private CustomerCreateCmd GetCustomerCreateCmd()
        {
            return new CustomerCreateCmd
            {
                Id = "2",
                FirstName = "Carlos",
                LastName = "Capella"
            };
        }

        private Customer GetCreatedCustomer()
        {
            return new Customer
            {
                Id = "2",
                FirstName = "Carlos",
                LastName = "Capella"
            };
        }

        [Fact]
        private void CreateCustomerShouldReturnOk()
        {
            var customerCreateCmd = GetCustomerCreateCmd();

            var createdCustomer = GetCreatedCustomer();

            _customerService.Setup(x => x.Create(It.IsAny<CustomerCreateCmd>()))
                .Returns(createdCustomer);
                
 
            var response = _customersController.CreateCustomer(customerCreateCmd);

            var result = Assert.IsType<CreatedResult>(response);

            Assert.Equal(201, result.StatusCode);
            Assert.NotNull(result.Value);

            var responseData = Assert.IsType<Customer>(result.Value);

            Assert.NotNull(responseData);
            Assert.NotNull(responseData.Id);
            Assert.NotNull(responseData.FirstName);
        }

        [Fact]
        private void CreateCustomerShouldReturnPreconditionFailedOnNameOrlastName()
        {
            _customerService.Setup(x => x.Create(It.IsAny<CustomerCreateCmd>()))
                .Throws(new GenericValidationException());

            var customerCreateCmd = GetCustomerCreateCmd();

            var response = _customersController.CreateCustomer(customerCreateCmd);

            var result = Assert.IsType<ObjectResult>(response);

            Assert.Equal(412, result.StatusCode);
        }


        [Fact]
        private void CreateCustomerShouldReturnPreconditionFailedOnDuplicatedPK()
        {
            _customerService.Setup(x => x.Create(It.IsAny<CustomerCreateCmd>()))
                .Throws(new DuplicatedPrimaryKeyException());

            var customerCreateCmd = GetCustomerCreateCmd();

            var response = _customersController.CreateCustomer(customerCreateCmd);

            var result = Assert.IsType<StatusCodeResult>(response);

            Assert.Equal(412, result.StatusCode);
        }

        [Fact]
        private void CreateCustomerShouldReturnBadRequest()
        {
            _customerService.Setup(x => x.Create(It.IsAny<CustomerCreateCmd>()))
                .Throws(new Exception());

            var customerCreateCmd = GetCustomerCreateCmd();

            var response = _customersController.CreateCustomer(customerCreateCmd);

            var result = Assert.IsType<BadRequestResult>(response);

            Assert.Equal(400, result.StatusCode);
        }


        #endregion

    }
}
