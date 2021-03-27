using Api_NetCore_Example.Models;
using Api_NetCore_Example.Models.Exceptions;
using Api_NetCore_Example.Repositories;
using Api_NetCore_Example.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Api_NetCore_Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        protected readonly ILogger<CustomersController> _logger;

        public CustomersController(
            ICustomerService customersService,
            ILogger<CustomersController> logger)
        {
            _customerService = customersService;
            _logger = logger;
        }

        // customers
        [HttpGet()]
        public IActionResult GetAllCustomers()
        {
            try
            {
                _logger.LogInformation("buscando todos los customer");
                var customerList = _customerService.GetAll();
                return Ok(customerList);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // customers/{customerId}
        [HttpGet("{customerId}")]
        public IActionResult GetCustomer([FromRoute] string customerId)
        {
            try
            {
                var customer = _customerService.Find(customerId);

                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }            
        }

        // /customers
        [HttpPost()]
        public IActionResult CreateCustomer(CustomerCreateCmd command)
        {
            try
            {
                _logger.LogInformation("creando un nuevo customer");

                var newCustomer = _customerService.Create(command);
                return Created($"https://localhost:8001/customers/{command.Id}", newCustomer);
            }
            catch(GenericValidationException ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(412, ex.ValidationErrors);
            }
            catch (DuplicatedPrimaryKeyException ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(412);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        // customers/{customerId}
        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomer([FromRoute] string customerId, CustomerUpdateCmd command)
        {
            try
            {
                var customer = _customerService.Update(customerId, command);

                return Ok(customer);

            }
            catch(NotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }            
        }

        // /customers/{customerId}
        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer([FromRoute] string customerId)
        {
            try
            {
                var deletedCustomer = _customerService.Delete(customerId);
                return Ok(deletedCustomer);
            }
            catch(NotFoundException ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return BadRequest();
            }
        }
    }
}
