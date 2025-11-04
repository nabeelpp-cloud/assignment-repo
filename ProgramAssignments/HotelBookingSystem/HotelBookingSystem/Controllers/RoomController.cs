using HotelBookingSystem.DTOs;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            try
            {
                var resp = await _roomService.GetRoom(id);
                if (resp == null)
                {
                    return NotFound();
                }
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(RoomDto roomDto)

        {
            Room room = new Room();
            room.RoomNumber = roomDto.RoomNumber;
            room.HotelId = roomDto.HotelId;
            room.RoomTypeId = roomDto.RoomTypeId;
            room.Status = (HotelBookingSystem.Models.RoomStatus)roomDto.Status;
            room.PricePerNight = roomDto.PricePerNight;
            var resp =await _roomService.CreateRoom(room);
            if (resp == null)
                return BadRequest("Failed to add booking");
            return Ok(resp);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, RoomDto roomDto)
        {
            var resp = await _roomService.UpdateRoom(id, roomDto);
            if (resp.Contains("NotFound"))
                return NotFound();
            if (resp.Contains("Error"))
                return BadRequest();
            return Ok(resp);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var resp = await _roomService.RemoveRoom(id);
            if (resp.Contains("NotFound"))
                return NotFound();
            if (resp.Contains("Error"))
                return BadRequest();
            return Ok(resp);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var resp = await _roomService.GetAllRooms();
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }
    }
}
