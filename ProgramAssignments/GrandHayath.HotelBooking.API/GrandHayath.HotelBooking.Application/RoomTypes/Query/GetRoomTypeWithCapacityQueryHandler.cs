using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.RoomTypes.Query
{
    public class GetRoomTypeWithCapacityQueryHandler : IRequestHandler<GetRoomTypeWithCapacityQuery, List<RoomTypeWithCapacityDto>>
    {
        private readonly ApplicationDbContext context;

        public GetRoomTypeWithCapacityQueryHandler(ApplicationDbContext context) 
        {
            this.context = context;
        }
        public async Task<List<RoomTypeWithCapacityDto>> Handle(GetRoomTypeWithCapacityQuery request, CancellationToken cancellationToken)
        {
            var roomTypes =await context.RoomTypes.ToListAsync(cancellationToken);
            List< RoomTypeWithCapacityDto> roomTypeDtos= new List< RoomTypeWithCapacityDto>();
            foreach (var roomType in roomTypes) 
            {
                RoomTypeWithCapacityDto roomTypeDto = new RoomTypeWithCapacityDto();
                roomTypeDto.TypeName=roomType.TypeName;
                roomTypeDto.Capacity = roomType.Capacity;
                roomTypeDtos.Add(roomTypeDto);
            }
            return roomTypeDtos;
        }
    }
}
