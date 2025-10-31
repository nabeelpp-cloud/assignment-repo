using MediatR;

namespace GrandHayath.HotelBooking.Application.RoomTypes.Command
{
    public class UpdateRoomTypeCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? TypeName { get; set; }
        public string? Description { get; set; }
        public int? Capacity { get; set; }
    }
}
