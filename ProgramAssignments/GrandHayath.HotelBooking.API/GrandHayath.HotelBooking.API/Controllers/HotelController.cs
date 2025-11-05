using GrandHayath.HotelBooking.Application.Hotels.Command;
using GrandHayath.HotelBooking.Application.Hotels.Query;
using GrandHayath.HotelBooking.Application.Rooms.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrandHayath.HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IMediator mediator;

        public HotelController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllHotelQuery getAllHotelQuery = new GetAllHotelQuery();
            var response =await mediator.Send(getAllHotelQuery);
            if(response != null) 
                return Ok(response);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            GetHotelByIdQuery query = new GetHotelByIdQuery();
            query.Id = id;
            var response =await mediator.Send(query);
            if (response != null)
                return Ok(response);
            return NotFound();
        }
        [HttpPost]
        public async Task<int> Add(CreateHotelCommand command)
        {
            return await mediator.Send(command);
        }
        [HttpDelete]
        public async Task<int> Delete(int id)
        {
            DeleteHotelCommand command = new DeleteHotelCommand();
            command.Id = id;
            return await mediator.Send(command);
        }
        [HttpPatch("{id}")]
        public async Task<int> Update(int id,UpdateHotelCommand command)
        {
            command.Id = id;
            return await mediator.Send(command);
        }
    }
}
