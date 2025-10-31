using GrandHayath.HotelBooking.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Application.RoomTypes.Query
{
    public class GetRoomTypeWithCapacityQuery : IRequest<List<RoomTypeWithCapacityDto>>
    {

    }
}
