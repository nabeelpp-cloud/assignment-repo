using System.Diagnostics.CodeAnalysis;

namespace GrandHayath.HotelBooking.Domain.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdProofNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
