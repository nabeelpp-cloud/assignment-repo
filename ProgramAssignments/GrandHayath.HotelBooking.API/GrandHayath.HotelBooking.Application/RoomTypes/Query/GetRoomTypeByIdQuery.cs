using GrandHayath.HotelBooking.Domain.Entity;
using MediatR;

namespace GrandHayath.HotelBooking.Application.RoomTypes.Query
{
    public class GetRoomTypeByIdQuery : IRequest<RoomType>
    {
        public int Id { get; set; } 
    }
}
