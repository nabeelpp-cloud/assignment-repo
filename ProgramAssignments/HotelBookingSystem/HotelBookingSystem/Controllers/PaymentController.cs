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
        public IActionResult Add(Payment payment)
        {
            

            var result = _paymentService.CreatePayment(payment);

            if (result == "Error creating payment")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch]
        public IActionResult Update([FromQuery] int id,
                                    [FromQuery] int? bookingId,
                                    [FromQuery] DateTime? paymentDate,
                                    [FromQuery] decimal? amount,
                                    [FromQuery] PaymentMethod? method,
                                    [FromQuery] PaymentStatus? status)
        {
            var response = _paymentService.UpdatePayment(id, bookingId, paymentDate, amount, method, status);

            if (response.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(response);

            if (response.Contains("Error", StringComparison.OrdinalIgnoreCase))
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var payment = _paymentService.GetPayment(id);

            if (payment == null)
                return NotFound("Payment not found");

            return Ok(payment);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = _paymentService.RemovePayment(id);

            if (response.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(response);

            if (response.Contains("Error", StringComparison.OrdinalIgnoreCase))
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var payments = _paymentService.GetAllPayments();

            if (payments == null || !payments.Any())
                return NotFound("No payments found");

            return Ok(payments);
        }
    }
}
