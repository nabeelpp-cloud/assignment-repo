using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Hotels.Query
{
    public class GetHotelWithRoomsQueryHandler : IRequestHandler<GetHotelWithRoomsQuery, HotelWithRoomsDto>
    {
        private readonly IApplicationDbContext _context;

        public GetHotelWithRoomsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<HotelWithRoomsDto> Handle(GetHotelWithRoomsQuery request, CancellationToken cancellationToken)
        {
            var hotel = await _context.Hotels
                .Include(h => h.Rooms)
                .ThenInclude(n=>n.RoomType)
                .FirstOrDefaultAsync(x=>x.Id == request.Id);
            HotelWithRoomsDto hotelWithRoomsDto = new HotelWithRoomsDto();
            if (hotel != null)
            {
                hotelWithRoomsDto.Id = hotel.Id;
                hotelWithRoomsDto.Name = hotel.Name;
                List<RoomDto> roomDtos = new List<RoomDto>();
                foreach (var room in hotel.Rooms)
                {
                    RoomDto roomDto = new RoomDto();
                    roomDto.RoomNumber = room.RoomNumber;
                    roomDto.HotelId = room.HotelId;
                    roomDto.RoomType = room.RoomType.TypeName;
                    roomDto.Status = room.Status;
                    roomDto.PricePerNight = room.PricePerNight;
                    roomDtos.Add(roomDto);
                }
                hotelWithRoomsDto.Rooms=roomDtos;
            }
            return hotelWithRoomsDto;
        }
    }
}
