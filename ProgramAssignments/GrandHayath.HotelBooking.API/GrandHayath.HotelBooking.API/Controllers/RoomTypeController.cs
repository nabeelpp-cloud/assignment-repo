using GrandHayath.HotelBooking.Application.RoomTypes.Command;
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
        public Task<int> Update(UpdateRoomTypeCommand updateRoomTypeCommand) 
        {
            var resp = mediator.Send(updateRoomTypeCommand);
            return resp;
        }
        [HttpDelete("{id}")]
        public Task<int> Delete(DeleteRoomTypeCommand deleteRoomTypeCommand) 
        {
            var resp = mediator.Send(deleteRoomTypeCommand);
            return resp;
        }
    }
}
