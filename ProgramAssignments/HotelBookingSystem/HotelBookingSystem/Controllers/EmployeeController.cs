using HotelBookingSystem.Models;
using HotelBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult Add([FromQuery] int hotelId,
                                 [FromQuery] string fullName,
                                 [FromQuery] string role,
                                 [FromQuery] string email)
        {
            Employee employee = new Employee
            {
                HotelId = hotelId,
                FullName = fullName,
                Role = role,
                Email = email
            };

            var result = _employeeService.CreateEmployee(employee);

            if (result.Contains("Error"))
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch]
        public IActionResult Update([FromQuery] int id,
                                    [FromQuery] int? hotelId,
                                    [FromQuery] string? fullName,
                                    [FromQuery] string? role,
                                    [FromQuery] string? email)
        {
            var result = _employeeService.UpdateEmployee(id, hotelId, fullName, role, email);

            if (result.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(result);

            if (result.Contains("Error", StringComparison.OrdinalIgnoreCase))
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            if (employee == null)
                return NotFound("Employee not found");

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _employeeService.RemoveEmployee(id);

            if (result.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(result);

            if (result.Contains("Error", StringComparison.OrdinalIgnoreCase))
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employeeService.GetAllEmployees();

            if (employees == null || !employees.Any())
                return NotFound("No employees found");

            return Ok(employees);
        }
    }
}
