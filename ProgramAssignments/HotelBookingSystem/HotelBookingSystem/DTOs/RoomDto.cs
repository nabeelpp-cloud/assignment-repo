using HotelBookingSystem.Models;
using System.Diagnostics.CodeAnalysis;

namespace HotelBookingSystem.DTOs
{
    public class RoomDto
    {
        public string RoomNumber { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public RoomStatus Status { get; set; }

        public decimal PricePerNight { get; set; }



    }
    public enum RoomStatus
    {
        Available,
        Booked,
        UnderMaintenance
    }
}
