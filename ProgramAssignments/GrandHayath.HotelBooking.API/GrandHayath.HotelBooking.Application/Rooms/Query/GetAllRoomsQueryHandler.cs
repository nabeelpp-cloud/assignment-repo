using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Rooms.Query
{
    public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery,List<RoomDto>>
    {
        private readonly ApplicationDbContext dbContext;

        public GetAllRoomsQueryHandler(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<List<RoomDto>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await dbContext.Rooms.ToListAsync();
            if (rooms != null)
            {
                List<RoomDto> roomDtos = new List<RoomDto>();
                foreach (var room in rooms)
                {
                    RoomDto roomDto = new RoomDto();
                    roomDto.RoomNumber = room.RoomNumber;
                    roomDto.HotelId = room.HotelId;
                    roomDto.RoomType = room.RoomType.TypeName;
                    roomDto.Status = room.Status;
                    roomDto.PricePerNight = room.PricePerNight;
                    roomDtos.Add(roomDto);
                }
                return roomDtos;
            }
            return null;
        }
    }
}
