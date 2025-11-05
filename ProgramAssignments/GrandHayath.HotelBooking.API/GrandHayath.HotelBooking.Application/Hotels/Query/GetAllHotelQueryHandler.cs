using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Hotels.Query
{
    public class GetAllHotelQueryHandler : IRequestHandler<GetAllHotelQuery, List<HotelDto>>
    {
        private readonly ApplicationDbContext dbContext;

        public GetAllHotelQueryHandler(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<HotelDto>> Handle(GetAllHotelQuery request, CancellationToken cancellationToken)
        {
            var hotels = await dbContext.Hotels.ToListAsync(cancellationToken);

            List<HotelDto> hotelDtos = new List<HotelDto>();
            foreach(var hotel in hotels)
            {
                HotelDto hotelDto = new HotelDto();
                hotelDto.Id = hotel.Id;
                hotelDto.Name = hotel.Name;
                hotelDto.Address = hotel.Address;
                hotelDto.City = hotel.City;
                hotelDto.Country = hotel.Country;
                hotelDto.PhoneNumber = hotel.PhoneNumber;
                hotelDtos.Add(hotelDto);
            }
            return hotelDtos;
        }
    }
}
