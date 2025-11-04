using HotelBookingSystem.Models;

namespace HotelBookingSystem.DTOs
{
    public class EmployeeDto
    {
        public int HotelId { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}
