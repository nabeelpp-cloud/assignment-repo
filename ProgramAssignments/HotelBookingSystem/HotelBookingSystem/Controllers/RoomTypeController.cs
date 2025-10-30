using HotelBookingSystem.Models;
using HotelBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService roomTypeService;
        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            this.roomTypeService = roomTypeService;
        }
        [HttpGet]
        public ActionResult GettAllRoomTypes()
        {
            try
            {
                var resp = roomTypeService.GetAllRoomTypes();
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
        [HttpGet("{id}")]
        public IActionResult GetRoomTypeById(int id)
        {
            try
            {
                var resp = roomTypeService.GetRoomType(id);
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
        public IActionResult CreateRoomType(string typeName, string description, int capacity)
        {
            RoomType roomType = new RoomType();
            roomType.TypeName = typeName;
            roomType.Description = description;
            roomType.Capacity = capacity;
            var resp = roomTypeService.AddRoomType(roomType);
            if (resp.Contains("NotFound"))
                return NotFound();
            if (resp.Contains("Error"))
                return BadRequest(resp);
            return Ok(resp);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoomType(int id) 
        {
            var resp=roomTypeService.RemoveRoomType(id);
            if (resp.Contains("NotFound"))
                return NotFound();
            if (resp.Contains("Error"))
                return BadRequest(resp);
            return Ok(resp);
        }
        [HttpPatch("{id}")]
        public IActionResult UpdateRoomType(int id, string? typeName, string? description, int? capacity)
        {
            var resp = roomTypeService.UpdateRoomType(id, typeName, description, capacity);
            if (resp.Contains("NotFound"))
                return NotFound();
            if (resp.Contains("Error"))
                return BadRequest(resp);
            return Ok(resp);
        }
    }
}
