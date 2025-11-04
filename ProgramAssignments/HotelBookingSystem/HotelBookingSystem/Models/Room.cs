using System.Diagnostics.CodeAnalysis;

namespace HotelBookingSystem.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int HotelId {  get; set; }
        public int RoomTypeId {  get; set; }
        public RoomStatus Status { get; set; }

        public decimal PricePerNight {  get; set; }

        public Hotel Hotel { get; set; }
        public RoomType RoomType {  get; set; }
        [AllowNull]
        public ICollection<Booking> Bookings { get; set; } 
        
    }
    public enum RoomStatus { 
        Available, 
        Booked, 
        UnderMaintenance 
    }
}
