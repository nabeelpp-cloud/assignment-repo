using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Application.RoomTypes.Query
{
    public class GetRoomTypeWithCapacityQuery : IRequest<RoomTypeWithCapacityDto>
    {

    }
    public class GetRoomTypeWithCapacityQueryHandler : IRequestHandler<GetRoomTypeWithCapacityQuery, RoomTypeWithCapacityDto>
    {
        private readonly ApplicationDbContext context;

        public GetRoomTypeWithCapacityQueryHandler(ApplicationDbContext context) 
        {
            this.context = context;
        }
        public async Task<RoomTypeWithCapacityDto> Handle(GetRoomTypeWithCapacityQuery request, CancellationToken cancellationToken)
        {
            var roomTypes =await context.RoomTypes.ToListAsync(cancellationToken);
            RoomTypeWithCapacityDto roomTypeDto= new RoomTypeWithCapacityDto();
            foreach (var roomType in roomTypes) 
            {
                roomTypeDto.TypeName=roomType.TypeName;
                roomTypeDto.Capacity = roomType.Capacity;

            }
            return roomTypeDto;
        }
    }
}
