using GrandHayath.HotelBooking.Application.Customers.Command;
using GrandHayath.HotelBooking.Application.Customers.Query;
using GrandHayath.HotelBooking.Application.Hotels.Command;
using GrandHayath.HotelBooking.Application.Hotels.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrandHayath.HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllCustomerQuery getAllCustomerQuery = new GetAllCustomerQuery();
            var response = await mediator.Send(getAllCustomerQuery);
            if (response != null)
                return Ok(response);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            GetCustomerByIDQuery getCustomerByIDQuery = new GetCustomerByIDQuery();
            getCustomerByIDQuery.Id = id;
            var response = await mediator.Send(getCustomerByIDQuery);
            if (response != null)
                return Ok(response);
            return NotFound();
        }
        [HttpPost]
        public async Task<int> Add(CreateCustomerCommand command)
        {
            return await mediator.Send(command);
        }
        [HttpDelete]
        public async Task<int> Delete(int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand();
            command.Id = id;
            return await mediator.Send(command);
        }
        [HttpPatch("{id}")]
        public async Task<int> Update(int id, UpdateCustomerCommand command)
        {
            command.Id = id;
            return await mediator.Send(command);
        }
        [HttpGet("{id}/bookings")]
        public async Task<IActionResult> GetCustomerBookings(int id)
        {
            GetCustomerWithBookingsQuery query = new GetCustomerWithBookingsQuery();
            query.Id = id;
            var response = await mediator.Send(query);
            if (response != null)
                return Ok(response);
            return NotFound();
        }
    }
}
