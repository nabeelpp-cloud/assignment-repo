using System.Diagnostics.CodeAnalysis;

namespace GrandHayath.HotelBooking.Domain.Entity
{
    public class Hotel
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    }
}
