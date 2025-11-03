using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Rooms.Query
{
    public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomDto>
    {
        private readonly ApplicationDbContext dbContext;

        public GetRoomByIdQueryHandler(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<RoomDto?> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {

            var room = await dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            RoomDto roomDto = new RoomDto();
            if (room != null)
            {
                roomDto.RoomNumber = room.RoomNumber;
                roomDto.HotelId = room.HotelId;
                roomDto.RoomTypeId = room.RoomTypeId;
                roomDto.Status = room.Status;
                roomDto.PricePerNight = room.PricePerNight;
                return roomDto;
            }
            return null;
        }
    }
}
