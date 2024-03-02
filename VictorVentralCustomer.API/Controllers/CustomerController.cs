using Microsoft.AspNetCore.Mvc;
using VictorVentralCustomer.Application.Customers.Dtos;
using VictorVentralCustomer.Application.Customers.Exceptions;
using VictorVentralCustomer.Application.Customers.Interfaces;

namespace VictorVentralCustomer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService customerService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;

        [HttpGet("/GetAllCustomers")]
        public async Task<ActionResult<List<GetCustomer>>> GetAllCustomers()
        {
            try
            {
                return Ok(await _customerService.GetAllCustomersAsync());
            }
            catch(CustomerEmptyListException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("/GetCustomerById/{id:int}")]
        public async Task<ActionResult<GetCustomer>> GetCustomerById(int id)
        {
            try
            {
                return Ok(await _customerService.GetCustomerByIdAsync(id));
            }
            catch (CustomerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost("/AddCustomer")]
        public async Task<ActionResult<CreatedCustomerResponse>> AddCustomerAsync(CreateCustomer newCustomer)
        {
            try
            {

                return Ok(await _customerService.AddCustomerAsync(newCustomer));
            }
            catch (InvalidCustomerException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/UpdateCustomerById/{id:int}")]
        public async Task<ActionResult<UpdatedCostumerResponse>> UpdateCustomerById(int id, CreateCustomer newCustomer)
        {
            try
            {
                return Ok(await _customerService.UpdateCustomerAsync(id, newCustomer));
            }
            catch (UpdatingCustomerFailedException ex)
            {

                return BadRequest(ex.Message);

            }

        }

        [HttpDelete("/DeleteCustomerById/{id:int}")]
        public async Task<ActionResult<List<DeletedCustomerResponse>>> DeleteCustomerById(int id)
        {
            try
            {
                return Ok(await _customerService.DeleteCustomerAsync(id));
            }
            catch (CustomerNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
