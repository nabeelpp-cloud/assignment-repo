using GrandHayath.HotelBooking.Application.Dtos;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Rooms.Query
{
    public class GetRoomByIdQuery : IRequest<RoomDto?> 
    {
        public int Id { get; set; }
    }
}
