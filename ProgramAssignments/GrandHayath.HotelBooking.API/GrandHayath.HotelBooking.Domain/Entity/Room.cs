using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GrandHayath.HotelBooking.Domain.Entity
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int HotelId {  get; set; }
        public int RoomTypeId {  get; set; }
        public RoomStatus Status { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PricePerNight {  get; set; }

        public Hotel Hotel { get; set; }
        public RoomType RoomType {  get; set; }

        public ICollection<Booking> Bookings { get; set; }  = new List<Booking>();
        
    }
    public enum RoomStatus { 
        Available, 
        Booked, 
        UnderMaintenance 
    }
}
