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
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(BookingDto bookingDto)
        {
            Booking booking = new Booking
            {
                CustomerId = bookingDto.CustomerId,
                RoomId = bookingDto.RoomId,
                CheckInDate = bookingDto.CheckInDate,
                CheckOutDate = bookingDto.CheckOutDate,
                TotalAmount = bookingDto.TotalAmount
            };

            var result = await _bookingService.CreateBooking(booking);

            if (result == null)
                return BadRequest("Failed to add booking");

            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, BookingDto bookingDto)
        {
            string response = await _bookingService.UpdateBooking(id, bookingDto);

            if (response == "Not Found")
                return NotFound("Booking not found");

            if (response == "Error")
                return BadRequest("Failed to update booking");

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var resp = await _bookingService.GetBooking(id);
            if (resp == null)
                return NotFound(resp);
            return Ok(resp);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var resp = await _bookingService.RemoveBooking(id);
            if (resp.Contains("NotFound"))
                return NotFound(resp);
            if (resp.Contains("Error"))
                return BadRequest(resp);
            return Ok(resp);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var resp = await _bookingService.GetAllBookings();
            if (resp == null)
                return NotFound(resp);
            return Ok(resp);

        }


    }
}
