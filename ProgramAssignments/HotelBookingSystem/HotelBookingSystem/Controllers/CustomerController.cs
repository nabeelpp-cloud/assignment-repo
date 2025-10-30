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
        public ActionResult GetAll() 
        {
            var resp=_customerService.GetCustomers();
            if(resp == null) 
                return NotFound();
            return Ok(resp);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id) 
        {
            var resp=_customerService.GetCustomerByCustomerId(id);
            if (resp == null)
                return NotFound();
            return Ok(resp);
        }
        [HttpPost]
        public ActionResult Create( string fullName, string email, string phoneNumber, string idProofNumber)
        {
            Customer customer = new Customer();
            customer.FullName = fullName;
            customer.Email = email;
            customer.PhoneNumber = phoneNumber;
            customer.IdProofNumber = idProofNumber;
            try
            {

                var resp = _customerService.AddCustomer(customer);
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
        public ActionResult Update(int id, string? fullName, string? email, string? phoneNumber, string? idProofNumber)
        {
            var res = _customerService.UpdateCustomer(id, fullName, email, phoneNumber, idProofNumber);
            if (res.Contains("Error"))
                return BadRequest();
            if(res.Contains("NotFound"))
                return NotFound();
            return Ok(res);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            var resp= _customerService.DeleteCustomer(id);
            if (resp.Contains("Error"))
                return BadRequest();
            if (resp.Contains("NotFound"))
                return NotFound();
            return Ok(resp);
        }
    }
}
