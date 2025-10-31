using HotelBookingSystem.DTOs;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(PaymentDto paymentDto)
        {
            var result = await _paymentService.CreatePayment(paymentDto);

            if (result == "Error creating payment")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(int id, PaymentDto paymentDto)
        {
            var response = await _paymentService.UpdatePayment(id, paymentDto);

            if (response.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(response);

            if (response.Contains("Error", StringComparison.OrdinalIgnoreCase))
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var payment = await _paymentService.GetPayment(id);

            if (payment == null)
                return NotFound("Payment not found");

            return Ok(payment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _paymentService.RemovePayment(id);

            if (response.Contains("not found"))
                return NotFound(response);

            if (response.Contains("Error"))
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments = await _paymentService.GetAllPayments();

            if (payments == null || !payments.Any())
                return NotFound("No payments found");

            return Ok(payments);
        }
    }
}
