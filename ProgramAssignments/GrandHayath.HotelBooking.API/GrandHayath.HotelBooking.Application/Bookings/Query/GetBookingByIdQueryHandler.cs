using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Bookings.Query
{
    public class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, BookingDetailsDto>
    {
        private readonly IApplicationDbContext dbContext;
        public GetBookingByIdQueryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<BookingDetailsDto> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            var booking =await dbContext.Bookings
                .Include(r => r.Room)
                    .ThenInclude(x => x.Hotel)
                .Include(r => r.Room)
                    .ThenInclude(x => x.RoomType)
                 .FirstOrDefaultAsync(b=>b.Id==request.Id);
            if (booking == null)
            {
                return null;
            }
            var bookingDto = new BookingDetailsDto
            {
                Id = booking.Id,
                CustomerId = booking.CustomerId,
                RoomId = booking.RoomId,
                HotelId = booking.Room.HotelId,
                RoomType = booking.Room.RoomType.TypeName,
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                TotalAmount = booking.TotalAmount,
                HotelName = booking.Room.Hotel.Name,
                Status = booking.Status,
                HotelAddress = $"{booking.Room.Hotel.Address}, {booking.Room.Hotel.City}, {booking.Room.Hotel.Country}"
            };
            return bookingDto;
        }
    }
}
