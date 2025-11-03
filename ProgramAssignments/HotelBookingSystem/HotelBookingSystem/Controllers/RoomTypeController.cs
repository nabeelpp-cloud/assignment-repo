using HotelBookingSystem.DTOs;
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
        public async Task<ActionResult> GetAllRoomTypes()
        {
            try
            {
                var resp = await roomTypeService.GetAllRoomTypes();
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
        public async Task<IActionResult> GetRoomTypeById(int id)
        {
            try
            {
                var resp = await roomTypeService.GetRoomType(id);
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
        public async Task<IActionResult> CreateRoomType(RoomTypeDto roomTypeDto)
        {
            RoomType roomType = new RoomType();
            roomType.TypeName = roomTypeDto.TypeName;
            roomType.Description = roomTypeDto.Description;
            roomType.Capacity = roomTypeDto.Capacity;
            var resp = await roomTypeService.AddRoomType(roomType);
            if (resp.Contains("NotFound"))
                return NotFound();
            if (resp.Contains("Error"))
                return BadRequest(resp);
            return Ok(resp);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomType(int id) 
        {
            var resp=await roomTypeService.RemoveRoomType(id);
            if (resp.Contains("NotFound"))
                return NotFound();
            if (resp.Contains("Error"))
                return BadRequest(resp);
            return Ok(resp);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRoomType(int id, RoomTypeDto roomTypeDto)
        {
            var resp =await roomTypeService.UpdateRoomType(id, roomTypeDto);
            if (resp.Contains("NotFound"))
                return NotFound();
            if (resp.Contains("Error"))
                return BadRequest(resp);
            return Ok(resp);
        }
    }
}
