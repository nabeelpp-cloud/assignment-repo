using GrandHayath.HotelBooking.Application.Dtos;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Bookings.Query
{
    public class GetBookingByCustomerIdQuery : IRequest<List<BookingDto>>
    {
        public int Id { get; set; }
    }
}
