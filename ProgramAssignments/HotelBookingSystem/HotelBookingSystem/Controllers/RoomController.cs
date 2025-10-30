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
        public IActionResult GetRoom(int id)
        {
            try
            {
                var resp = _roomService.GetRoom(id);
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
        [HttpPost("create")]
        public IActionResult AddRoom(
                    [FromQuery] string roomNumber,
                    [FromQuery] int hotelId,
                    [FromQuery] int roomTypeId,
                    [FromQuery] RoomStatus status,
                    [FromQuery] decimal pricePerNight)

        {
            Room room = new Room();
            room.RoomNumber = roomNumber;
            room.HotelId = hotelId;
            room.RoomTypeId = roomTypeId;
            room.Status = status;
            room.PricePerNight = pricePerNight;
            var resp = _roomService.CreateRoom(room);
            if (resp == null)
                return BadRequest("Failed to add booking");
            return Ok(resp);
        }
        [HttpPatch("{id}")]
        public IActionResult UpdateRoom(int id, [FromQuery] string? roomNumber,
                    [FromQuery] int? hotelId,
                    [FromQuery] int? roomTypeId,
                    [FromQuery] RoomStatus? status,
                    [FromQuery] decimal? pricePerNight)
        {
            var resp = _roomService.UpdateRoom(id, roomNumber, hotelId, roomTypeId, status, pricePerNight);
            if (resp.Contains("NotFound"))
                return NotFound();
            if (resp.Contains("Error"))
                return BadRequest();
            return Ok(resp);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var resp = _roomService.RemoveRoom(id);
            if (resp.Contains("NotFound"))
                return NotFound();
            if (resp.Contains("Error"))
                return BadRequest();
            return Ok(resp);
        }
        [HttpGet]
        public IActionResult GetAllRooms()
        {
            
            try
            {
                var resp = _roomService.GetAllRooms();
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
    }
}
