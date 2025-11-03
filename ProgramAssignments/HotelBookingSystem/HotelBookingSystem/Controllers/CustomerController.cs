using HotelBookingSystem.DTOs;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService) 
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() 
        {
            var resp=await _customerService.GetCustomers();
            if(resp == null) 
                return NotFound();
            return Ok(resp);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id) 
        {
            var resp=await _customerService.GetCustomerById(id);
            if (resp == null)
                return NotFound();
            return Ok(resp);
        }
        [HttpPost]
        public async Task<ActionResult> Create( CustomerDto customerDto)
        {
            Customer customer = new Customer();
            customer.FullName = customerDto.FullName;
            customer.Email = customerDto.Email;
            customer.PhoneNumber = customerDto.PhoneNumber;
            customer.IdProofNumber = customerDto.IdProofNumber;
            try
            {

                var resp = await _customerService.AddCustomer(customer);
                if (resp.Contains("Error"))
                    return BadRequest(resp);
                return Ok(resp);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, CustomerDto customerDto)
        {
            var res = await _customerService.UpdateCustomer(id, customerDto);
            if (res.Contains("Error"))
                return BadRequest();
            if(res.Contains("NotFound"))
                return NotFound();
            return Ok(res);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) 
        {
            var resp= await _customerService.DeleteCustomer(id);
            if (resp.Contains("Error"))
                return BadRequest();
            if (resp.Contains("NotFound"))
                return NotFound();
            return Ok(resp);
        }
    }
}
