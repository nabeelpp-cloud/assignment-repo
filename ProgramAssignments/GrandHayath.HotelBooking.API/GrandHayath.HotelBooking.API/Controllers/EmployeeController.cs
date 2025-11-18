using GrandHayath.HotelBooking.Application.Employees.Command;
using GrandHayath.HotelBooking.Application.Employees.Query;
using GrandHayath.HotelBooking.Application.Rooms.Command;
using GrandHayath.HotelBooking.Application.Rooms.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrandHayath.HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllEmployeeQuery getAll = new GetAllEmployeeQuery();
            var response = await mediator.Send(getAll);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetEmployeeByIdQuery getEmployeeById = new GetEmployeeByIdQuery();
            getEmployeeById.Id = id;
            var response = await mediator.Send(getEmployeeById);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
        [HttpPost]
        public async Task<int> Create(CreateEmployeeCommand command)
        {
            var response = await mediator.Send(command);
            return response;
        }
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            DeleteEmployeeCommand deleteemployee = new DeleteEmployeeCommand();
            deleteemployee.Id = id;
            var response = await mediator.Send(deleteemployee);
            return response;
        }
        [HttpPatch("{id}")]
        public async Task<int> Update(int id, UpdateEmployeeCommand command)
        {
            command.Id = id;
            var response = await mediator.Send(command);
            return response;
        }
    }
}
