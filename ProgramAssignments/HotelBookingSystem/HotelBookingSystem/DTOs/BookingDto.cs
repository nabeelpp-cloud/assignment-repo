using HotelBookingSystem.Models;

namespace HotelBookingSystem.DTOs
{
    public class BookingDto
    {
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
