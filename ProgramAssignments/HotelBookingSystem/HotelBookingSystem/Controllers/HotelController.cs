using HotelBookingSystem.Models;
using HotelBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost("create")]
        public IActionResult Add([FromQuery] string name, string address, string city, string country, string phoneNumber)
        {
            Hotel hotel = new Hotel();
            hotel.Name = name;
            hotel.Address = address;
            hotel.City = city;
            hotel.Country = country;
            hotel.PhoneNumber = phoneNumber;
            var resp = _hotelService.AddHotel(hotel);
            if (resp == null)
                return BadRequest("Failed adding new Hotel");
            return Ok(resp);
        }
        [HttpPatch("update")]
        public IActionResult Update([FromQuery] int id, string? name, string? address, string? city, string? country, string? phoneNumber)
        {
            Hotel hotel = new Hotel();
            hotel.Name = name;
            hotel.Address = address;
            hotel.City = city;
            hotel.Country = country;
            hotel.PhoneNumber = phoneNumber;
            string resp = _hotelService.UpdateHotel(id, hotel);
            if (resp.Contains("NotFound"))
                return NotFound(resp);
            if (resp.Contains("Error"))
                return BadRequest(resp);
            return Ok(resp);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var resp = _hotelService.GetById(id);
            if (resp == null)
                return NotFound(resp);
            return Ok(resp);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var resp = _hotelService.Delete(id);
            if (resp.Contains("NotFound"))
                return NotFound(resp);
            if (resp.Contains("Error"))
                return BadRequest(resp);
            return Ok(resp);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var resp = _hotelService.ListAll();
            if (resp == null)
                return NotFound(resp);
            return Ok(resp);

        }

    }
}
