using HotelBookingSystem.DTOs;
using HotelBookingSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Data;

namespace HotelBookingSystem.Services
{
    public interface IEmployeeService
    {
        public Task<string> CreateEmployee(Employee employee);
        public Task<string> UpdateEmployee(int id, EmployeeDto employeeDto);
        public Task<string> RemoveEmployee(int id);
        public Task<Employee> GetEmployee(int id);
        public Task<List<Employee>> GetAllEmployees();
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly HotelManagementDbContext _context;

        public EmployeeService(HotelManagementDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            int result =await _context.SaveChangesAsync();
            return result > 0 ? "Employee added successfully" : "Error adding employee";
        }

        public async Task<string> UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            var exsistingEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (exsistingEmployee == null)
                return "Employee not found";

            if (employeeDto.HotelId!=0 && employeeDto.HotelId!= exsistingEmployee.HotelId)
                exsistingEmployee.HotelId = employeeDto.HotelId;

            if (!string.IsNullOrWhiteSpace(employeeDto.FullName))
                exsistingEmployee.FullName = employeeDto.FullName;

            if (!string.IsNullOrWhiteSpace(employeeDto.Role))
                exsistingEmployee.Role = employeeDto.Role;

            if (!string.IsNullOrWhiteSpace(employeeDto.Email))
                exsistingEmployee.Email = employeeDto.Email;

            int result = await _context.SaveChangesAsync();
            return result > 0 ? "Employee updated successfully" : "Error updating employee";
        }



        public async Task<string> RemoveEmployee(int id)
        {
            var employee =await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null) return "Employee not found";

            _context.Employees.Remove(employee);
            int result =await _context.SaveChangesAsync();
            return result > 0 ? "Employee deleted successfully" : "Error deleting employee";
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee=await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            return employee;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
