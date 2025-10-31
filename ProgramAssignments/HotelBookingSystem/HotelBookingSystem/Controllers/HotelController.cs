using HotelBookingSystem.DTOs;
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
        public async Task<IActionResult> Add(HotelDto hotelDto)
        {
            Hotel hotel = new Hotel();
            hotel.Name = hotelDto.Name;
            hotel.Address = hotelDto.Address;
            hotel.City = hotelDto.City;
            hotel.Country = hotelDto.Country;
            hotel.PhoneNumber = hotelDto.PhoneNumber;
            var resp = await _hotelService.AddHotel(hotel);
            if (resp == null)
                return BadRequest("Failed adding new Hotel");
            return Ok(resp);
        }
        [HttpPatch("update")]
        public async Task<IActionResult> Update(int id, HotelDto hotelDto)
        {
            
            string resp = await _hotelService.UpdateHotel(id, hotelDto);
            if (resp.Contains("NotFound"))
                return NotFound(resp);
            if (resp.Contains("Error"))
                return BadRequest(resp);
            return Ok(resp);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var resp = await _hotelService.GetById(id);
            if (resp == null)
                return NotFound(resp);
            return Ok(resp);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var resp = await _hotelService.Delete(id);
            if (resp.Contains("NotFound"))
                return NotFound(resp);
            if (resp.Contains("Error"))
                return BadRequest(resp);
            return Ok(resp);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var resp = await _hotelService.ListAll();
            if (resp == null)
                return NotFound(resp);
            return Ok(resp);

        }

    }
}
