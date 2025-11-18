using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Bookings.Query
{
    public class GetBookingByCustomerIdQueryHandler : IRequestHandler<GetBookingByCustomerIdQuery, List<BookingDto>>
    {
        private readonly IApplicationDbContext dbContext;
        public GetBookingByCustomerIdQueryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<BookingDto>> Handle(GetBookingByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var bookings = await dbContext.Bookings
                .Include(r=>r.Room)
                    .ThenInclude(x=>x.Hotel)
                .Include(r=>r.Room)
                    .ThenInclude(x=>x.RoomType)
                .Where(b => b.CustomerId == request.Id)
                .ToListAsync();
            if (bookings == null)
            {
                return null;
            }
            List<BookingDto> bookingDtos = new List<BookingDto>();
            foreach(var booking in bookings)
            {

                var bookingDto = new BookingDto
                {
                    Id = booking.Id,
                    CustomerId = booking.CustomerId,
                    RoomId = booking.RoomId,
                    RoomType = booking.Room.RoomType.TypeName,
                    CheckInDate = booking.CheckInDate,
                    CheckOutDate = booking.CheckOutDate,
                    TotalAmount = booking.TotalAmount,
                    HotelName = booking.Room.Hotel.Name,
                    Status = booking.Status,
                    HotelAddress = $"{booking.Room.Hotel.Address}, {booking.Room.Hotel.City}, {booking.Room.Hotel.Country}"
                };
                bookingDtos.Add(bookingDto);
            }
            return bookingDtos;
        }
    }
}
