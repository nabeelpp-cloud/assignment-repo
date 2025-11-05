using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Hotels.Query
{
    public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, HotelDto?>
    {
        private readonly ApplicationDbContext dbContext;

        public GetHotelByIdQueryHandler(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<HotelDto?> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
        {
            var hotel = await dbContext.Hotels.FindAsync(request.Id);
            if (hotel != null)
            {

                HotelDto hotelDto = new HotelDto();
                hotelDto.Id = hotel.Id;
                hotelDto.Name = hotel.Name;
                hotelDto.Address = hotel.Address;
                hotelDto.City = hotel.City;
                hotelDto.Country = hotel.Country;
                hotelDto.PhoneNumber = hotel.PhoneNumber;
                return hotelDto;
            }
            return null;
        }
    }
}
