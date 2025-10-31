using HotelBookingSystem.DTOs;
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
        public async Task<IActionResult> Add(EmployeeDto employeeDto)
        {
            Employee employee = new Employee
            {
                HotelId = employeeDto.HotelId,
                FullName = employeeDto.FullName,
                Role = employeeDto.Role,
                Email = employeeDto.Email
            };

            var result =await _employeeService.CreateEmployee(employee);

            if (result.Contains("Error"))
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update( int id,EmployeeDto employeeDto)
        {
            var result =await _employeeService.UpdateEmployee(id, employeeDto);

            if (result.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(result);

            if (result.Contains("Error", StringComparison.OrdinalIgnoreCase))
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee =await _employeeService.GetEmployee(id);
            if (employee == null)
                return NotFound("Employee not found");

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result =await _employeeService.RemoveEmployee(id);

            if (result.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(result);

            if (result.Contains("Error", StringComparison.OrdinalIgnoreCase))
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees =await _employeeService.GetAllEmployees();

            if (employees == null || !employees.Any())
                return NotFound("No employees found");

            return Ok(employees);
        }
    }
}
