using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Rooms.Command
{
    public class CreateRoomCommandHandler  : IRequestHandler<CreateRoomCommand, int>
    {
        private readonly IRoomRepository roomRepository;

        public CreateRoomCommandHandler(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Room
            {
                RoomTypeId = request.RoomTypeId,
                RoomNumber = request.RoomNumber,
                HotelId = request.HotelId,
                Status = request.Status,
                PricePerNight = request.PricePerNight,
            };
            return await  roomRepository.AddAsync(room);
        }
    }
}
