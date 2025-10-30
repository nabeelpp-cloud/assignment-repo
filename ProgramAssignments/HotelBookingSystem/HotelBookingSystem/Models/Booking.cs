namespace HotelBookingSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Customer Customer { get; set; }
        public Room Room { get; set; }
        public Payment Payment { get; set; }

    }
}
