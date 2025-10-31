using HotelBookingSystem.Models;
using System.Diagnostics.CodeAnalysis;

namespace HotelBookingSystem.DTOs
{
    public class CustomerDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdProofNumber { get; set; }

    }
}
