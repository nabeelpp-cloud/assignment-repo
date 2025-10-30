using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{
    public interface IEmployeeService
    {
        string CreateEmployee(Employee employee);
        string UpdateEmployee(int id, int? hotelId, string? fullName, string? role, string? email);
        string RemoveEmployee(int id);
        Employee GetEmployee(int id);
        List<Employee> GetAllEmployees();
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly HotelManagementDbContext _context;

        public EmployeeService(HotelManagementDbContext context)
        {
            _context = context;
        }

        public string CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            int result = _context.SaveChanges();
            return result > 0 ? "Employee added successfully" : "Error adding employee";
        }

        public string UpdateEmployee(int id, int? hotelId, string? fullName, string? role, string? email)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return "Employee not found";

            if (hotelId.HasValue) employee.HotelId = hotelId.Value;
            if (!string.IsNullOrEmpty(fullName)) employee.FullName = fullName;
            if (!string.IsNullOrEmpty(role)) employee.Role = role;
            if (!string.IsNullOrEmpty(email)) employee.Email = email;

            int result = _context.SaveChanges();
            return result > 0 ? "Employee updated successfully" : "Error updating employee";
        }

        public string RemoveEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return "Employee not found";

            _context.Employees.Remove(employee);
            int result = _context.SaveChanges();
            return result > 0 ? "Employee deleted successfully" : "Error deleting employee";
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }
    }
}
