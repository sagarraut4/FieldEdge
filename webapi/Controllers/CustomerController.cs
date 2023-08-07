using AutoMapper;
using CustomerServiceClient;
using Microsoft.AspNetCore.Mvc;
using ModelDto;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using webapi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("/")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerClient _customerClient;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerClient customerClient, IMapper mapper)
        {
            _customerClient=customerClient;
            _mapper=mapper;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        [Route("api/customer/getListofCustomer")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Customer>))]
        [SwaggerOperation("Get list of customers")]
        [ActionName("GetCustomers")]
        public async Task <IActionResult> Get()
        {
            try
            {
                var customerList = await _customerClient.GetCustomers();
                return Ok(_mapper.Map<IEnumerable<Customer>>(customerList.AsEnumerable()));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occured while processing the request" });
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet]
        [Route("api/customer/getCustomerById/{customerId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Customer))]
        [SwaggerOperation("Get customer by Id")]
        public async Task<IActionResult> Get([FromRoute][Required] int customerId)
        {
            try
            {
                var customer = await _customerClient.GetCustomer(customerId);
                return Ok(_mapper.Map<Customer>(customer));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occured while processing the request" });
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        [Route("api/customer")]
        [SwaggerOperation("Add customer")]
        public async Task<IActionResult>  Post([FromBody] [Required] Customer customer)
        {
            try
            {
                if(customer == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }
                var addedCustomer = await _customerClient.AddCustomer(_mapper.Map <CustomerDto>(customer));
                return Ok(_mapper.Map<Customer>(addedCustomer));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occured while processing the request" });
            }
            
        }

        // PUT api/<CustomerController>/5
        // PUT api/<CustomerController>/5
        [HttpPut]
        [Route("api/customer/updateCustomer/{customerId}")]
        [SwaggerOperation("Update customer")]
        public async Task<IActionResult> Put([FromRoute][Required] string customerId, [FromBody][Required] Customer customer)
        {
            try
            {
                if (customer == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }
                var updatedCustomer = await _customerClient.UpdateCustomer(customerId, _mapper.Map<CustomerDto>(customer));
                return Ok(_mapper.Map<Customer>(updatedCustomer));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occured while processing the request" });
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete]
        [Route("api/customer/deleteCustomer/{customerId}")]
        [SwaggerOperation("Delete customer")]
        public async Task<IActionResult> Delete([FromRoute][Required] int customerId)
        {
            try
            {
                var customer = await _customerClient.GetCustomer(customerId);
                return CreatedAtAction("GetCustomers",null);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occured while processing the request" });
            }
        }
    }
}
