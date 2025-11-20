using GrandHayath.HotelBooking.Application.Dtos;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Bookings.Query
{
    public class GetBookingByIdQuery : IRequest<BookingDetailsDto>
    {
        public int Id { get; set; }
    }
}
