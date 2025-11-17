using GrandHayath.HotelBooking.Application.Hotels.Command;
using GrandHayath.HotelBooking.Application.Hotels.Query;
using GrandHayath.HotelBooking.Application.Rooms.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrandHayath.HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllHotelQuery getAllHotelQuery = new GetAllHotelQuery();
            var response =await _mediator.Send(getAllHotelQuery);
            if(response != null) 
                return Ok(response);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            GetHotelByIdQuery query = new GetHotelByIdQuery();
            query.Id = id;
            var response =await _mediator.Send(query);
            if (response != null)
                return Ok(response);
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<int> Add(CreateHotelCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            DeleteHotelCommand command = new DeleteHotelCommand();
            command.Id = id;
            return await _mediator.Send(command);
        }
        [HttpPatch("{id}")]
        public async Task<int> Update(int id,UpdateHotelCommand command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
        [HttpGet("{id}/rooms")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetHotelWithRoomsByID(int id)
        {
            GetHotelWithRoomsQuery query = new GetHotelWithRoomsQuery();
            query.Id = id;
            var response = await _mediator.Send(query);
            if (response != null)
                return Ok(response);
            return NotFound();
        }
        [HttpGet("{id}/employees")]
        public async Task<IActionResult> GetHotelWithEmployees(int id)
        {
            var result = await _mediator.Send(new GetHotelWithEmployeesQuery { Id = id });
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetHotelWithReviews(int id)
        {
            var result = await _mediator.Send(new GetHotelWithReviewsQuery { Id = id });
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("full")]
        public async Task<IActionResult> GetHotelFullDetails(
            string? searchTerm ,
            DateTime? checkInDate , 
            DateTime? checkOutDate,
            string? selectedRatings,
            int pageNumber =1,
            int pageSize = 10,
            int minPrice = 0,
            int maxPrice = 1000)
        {
            var result = await _mediator.Send(new GetHotelFullDetailsQuery { 
                SearchTerm = searchTerm ,
                CheckInDate = checkInDate ,
                CheckOutDate = checkOutDate ,
                PageNumber = pageNumber ,
                PageSize = pageSize,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                StarRating = selectedRatings
            });
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet("full/{id}")]
        public async Task<IActionResult> GetHotelFullDetails(
            int id,
            DateTime? checkInDate , 
            DateTime? checkOutDate)
        {
            var result = await _mediator.Send(new GetHotelFullDetailsByIdQuery { 
                Id=id,
                CheckInDate = checkInDate ,
                CheckOutDate = checkOutDate 
            });
            if (result == null)
                return NotFound();
            return Ok(result);
        }

    }
}
