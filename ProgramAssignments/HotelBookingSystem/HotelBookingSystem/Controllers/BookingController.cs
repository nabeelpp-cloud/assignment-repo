using HotelBookingSystem.DTOs;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBoookingService _bookingService;
        public BookingController(IBoookingService boookingService)
        {
            _bookingService = boookingService;
        }

        [HttpPost("add")]
        public IActionResult Add(BookingDto bookingDto)
        {
            Booking booking = new Booking
            {
                CustomerId = bookingDto.CustomerId,
                RoomId = bookingDto.RoomId,
                CheckInDate = bookingDto.CheckInDate,
                CheckOutDate = bookingDto.CheckOutDate,
                TotalAmount = bookingDto.TotalAmount
            };

            var result = _bookingService.CreateBooking(booking);

            if (result == null)
                return BadRequest("Failed to add booking");

            return Ok(result);
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id,BookingDto bookingDto)
        {
            string response = _bookingService.UpdateBooking(id,bookingDto);

            if (response == "Not Found")
                return NotFound("Booking not found");

            if (response == "Error")
                return BadRequest("Failed to update booking");

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var resp = _bookingService.GetBooking(id);
            if (resp == null)
                return NotFound(resp);
            return Ok(resp);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var resp = _bookingService.RemoveBooking(id);
            if (resp.Contains("NotFound"))
                return NotFound(resp);
            if (resp.Contains("Error"))
                return BadRequest(resp);
            return Ok(resp);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var resp = _bookingService.GetAllBookings();
            if (resp == null)
                return NotFound(resp);
            return Ok(resp);

        }


    }
}
