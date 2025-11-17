using GrandHayath.HotelBooking.Application.Bookings.Command;
using GrandHayath.HotelBooking.Application.Bookings.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GrandHayath.HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var query = new GetBookingByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound("Booking not found.");

            return Ok(result);
        }
        [HttpGet("customer/{id}")]
        public async Task<IActionResult> GetBookingByCustomerId(int id)
        {
            var query = new GetBookingByCustomerIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound("Booking not found.");

            return Ok(result);
        }


        [HttpGet("admin/all")]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _mediator.Send(new GetAllBookingQuery());
            return Ok(result);
        }


        [HttpPost("cancel/{id}")]
        public async Task<IActionResult> CancelBooking(int id)
        {
            var command = new DeleteBookingCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result==0)
                return BadRequest("Unable to cancel booking.");

            return Ok("Booking cancelled successfully.");
        }
    }
}
