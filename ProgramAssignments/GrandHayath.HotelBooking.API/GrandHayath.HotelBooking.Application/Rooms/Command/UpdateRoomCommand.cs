using GrandHayath.HotelBooking.Domain.Entity;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Rooms.Command
{
    public class UpdateRoomCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? RoomNumber { get; set; }
        public int? HotelId { get; set; }
        public int? RoomTypeId { get; set; }
        public RoomStatus? Status { get; set; }
        public decimal? PricePerNight { get; set; }
    }
}
