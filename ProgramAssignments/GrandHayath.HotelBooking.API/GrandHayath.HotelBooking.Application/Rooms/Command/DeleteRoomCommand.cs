using MediatR;

namespace GrandHayath.HotelBooking.Application.Rooms.Command
{
    public class DeleteRoomCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
