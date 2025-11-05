using MediatR;

namespace GrandHayath.HotelBooking.Application.Bookings.Command
{
    public class DeleteBookingCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
