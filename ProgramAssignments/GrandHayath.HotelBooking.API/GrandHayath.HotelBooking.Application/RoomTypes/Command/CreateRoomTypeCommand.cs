using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.RoomTypes.Command
{
    public class CreateRoomTypeCommand : IRequest<int>
    {
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
    }
}
