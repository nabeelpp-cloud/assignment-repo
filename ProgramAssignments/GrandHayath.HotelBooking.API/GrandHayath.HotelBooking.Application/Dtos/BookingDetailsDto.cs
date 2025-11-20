using GrandHayath.HotelBooking.Domain.Entity;

namespace GrandHayath.HotelBooking.Application.Dtos
{
    public class BookingDetailsDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public string? HotelAddress { get; set; }
        public string? RoomType { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
