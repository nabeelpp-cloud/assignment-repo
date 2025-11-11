using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Customers.Query
{
    public class GetCustomerWithBookingsQueryHandler : IRequestHandler<GetCustomerWithBookingsQuery, CustomerWithBookingsDto>
    {
        private readonly IApplicationDbContext _context;

        public GetCustomerWithBookingsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerWithBookingsDto> Handle(GetCustomerWithBookingsQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers
                .Include(x=> x.Bookings)
                .FirstOrDefaultAsync(x=>x.Id == request.Id);
            if (customer != null) 
            {
                CustomerWithBookingsDto dto = new CustomerWithBookingsDto();
                dto.Id = customer.Id;
                dto.FullName = customer.FullName;
                List<BookingDto> bookingDtos = new List<BookingDto>();
                Console.WriteLine("List created",customer.Bookings.Count());
                foreach (var booking in customer.Bookings)
                {
                    Console.WriteLine(booking.CustomerId);
                    bookingDtos.Add(new BookingDto
                    {
                        Id = booking.Id,
                        CustomerId = booking.CustomerId,
                        RoomId = booking.RoomId,
                        CheckInDate = booking.CheckInDate,
                        CheckOutDate = booking.CheckOutDate,
                        TotalAmount = booking.TotalAmount
                    });
                }
                dto.Bookings = bookingDtos;
                return dto;
            }
            return null;
        }
    }
}
