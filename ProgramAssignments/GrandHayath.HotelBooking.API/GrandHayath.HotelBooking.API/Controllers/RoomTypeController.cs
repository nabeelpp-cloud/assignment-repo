using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Application.RoomTypes.Command;
using GrandHayath.HotelBooking.Application.RoomTypes.Query;
using GrandHayath.HotelBooking.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GrandHayath.HotelBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomTypeController : ControllerBase
    {
        private readonly IMediator mediator;

        public RoomTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public Task<int> Create(CreateRoomTypeCommand createRoomTypeCommand)
        {
            var resp= mediator.Send(createRoomTypeCommand);
            return resp;
        }
        [HttpPatch("{id}")]
        public Task<int> Update(int id) 
        {
            UpdateRoomTypeCommand updateRoomTypeCommand = new UpdateRoomTypeCommand();
            var resp = mediator.Send(updateRoomTypeCommand);
            return resp;
        }
        [HttpDelete("{id}")]
        public Task<int> Delete(int id) 
        {
            DeleteRoomTypeCommand deleteRoomTypeCommand = new DeleteRoomTypeCommand();
            var resp = mediator.Send(deleteRoomTypeCommand);
            return resp;
        }
        [HttpGet]
        public Task<List<RoomTypeWithCapacityDto>> Get()
        {
            GetRoomTypeWithCapacityQuery getRoomTypeWithCapacityQuery = new GetRoomTypeWithCapacityQuery();
            var resp = mediator .Send(getRoomTypeWithCapacityQuery);
            return resp;
        }
        [HttpGet("{id}")]
        public Task<RoomType> GetById(int id)
        {
            GetRoomTypeByIdQuery getRoomTypeByIdQuery = new GetRoomTypeByIdQuery();
            getRoomTypeByIdQuery.Id = id;
            var resp = mediator.Send(getRoomTypeByIdQuery);
            return resp;
        }
    }
}
