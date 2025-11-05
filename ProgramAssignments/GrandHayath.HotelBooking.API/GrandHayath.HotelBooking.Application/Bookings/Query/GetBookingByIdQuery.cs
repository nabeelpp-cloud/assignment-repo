using GrandHayath.HotelBooking.Application.Dtos;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Bookings.Query
{
    public class GetBookingByIdQuery : IRequest<BookingDto>
    {
        public int Id { get; set; }
    }
}
