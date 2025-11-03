using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Application.Rooms.Command;
using GrandHayath.HotelBooking.Application.Rooms.Query;
using GrandHayath.HotelBooking.Application.RoomTypes.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GrandHayath.HotelBooking.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IMediator mediator;

        public RoomController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllRoomsQuery getAll = new GetAllRoomsQuery();
            var response =await mediator.Send(getAll);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetRoomByIdQuery getRoomById = new GetRoomByIdQuery();
            getRoomById.Id = id;
            var response= await mediator.Send(getRoomById);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
        [HttpPost]
        public async Task<int> Create(CreateRoomCommand command)
        {
            var response = await mediator.Send(command);
            return response;
        }
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            DeleteRoomCommand deleteRoomType = new DeleteRoomCommand();
            deleteRoomType.Id = id;
            var response = await mediator.Send(deleteRoomType);
            return response;
        }
        [HttpPatch("{id}")]
        public async Task<int> Update(int id, UpdateRoomCommand command)
        {
            command.Id = id;
            var response = await mediator.Send(command);
            return response;
        }
    }
}
