using MediatR;

namespace GrandHayath.HotelBooking.Application.Bookings.Command
{
    public class UpdateBookingCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
