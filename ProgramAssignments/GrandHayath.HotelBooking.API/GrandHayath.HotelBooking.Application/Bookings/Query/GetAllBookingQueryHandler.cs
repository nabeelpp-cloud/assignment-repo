using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Bookings.Query
{
    public class GetAllBookingQueryHandler : IRequestHandler<GetAllBookingQuery, List<BookingDto>>
    {
        private readonly IApplicationDbContext dbContext;

        public GetAllBookingQueryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<BookingDto>> Handle(GetAllBookingQuery request, CancellationToken cancellationToken)
        {
            var bookings =await dbContext.Bookings.ToListAsync();
            List<BookingDto> bookingDtos = new List<BookingDto>();
            foreach (var booking in bookings)
            {
                bookingDtos.Add(new BookingDto
                {
                    Id = booking.Id,
                    CustomerId = booking.CustomerId,
                    RoomId = booking.RoomId,
                    CheckInDate = booking.CheckInDate,
                    CheckOutDate = booking.CheckOutDate,
                    TotalAmount = booking.TotalAmount,
                    Status=booking.Status,
                    
                });
            }
            return bookingDtos;
        }
    }
}
