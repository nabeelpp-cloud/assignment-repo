using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Bookings.Query
{
    public class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, BookingDto>
    {
        private readonly IApplicationDbContext dbContext;
        public GetBookingByIdQueryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<BookingDto> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            var booking =await dbContext.Bookings.FindAsync(request.Id);
            if (booking == null)
            {
                return null;
            }
            var bookingDto = new BookingDto
            {
                Id = booking.Id,
                CustomerId = booking.CustomerId,
                RoomId = booking.RoomId,
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                TotalAmount = booking.TotalAmount
            };
            return bookingDto;
        }
    }
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
                    CheckInDate = booking.CheckInDate,
                    CheckOutDate = booking.CheckOutDate,
                    TotalAmount = booking.TotalAmount
                };
                bookingDtos.Add(bookingDto);
            }
            return bookingDtos;
        }
    }
}
