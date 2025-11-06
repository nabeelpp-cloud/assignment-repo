using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Rooms.Command
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, int>
    {
        private readonly IRoomRepository _repository;

        public UpdateRoomCommandHandler(IRoomRepository roomRepository)
        {
            this._repository = roomRepository;
        }
        public async Task<int> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var existingRoom = await _repository.GetByIdAsync(request.Id);

            if (existingRoom == null)
            {
                return 0;
            }

            existingRoom.RoomTypeId = request.RoomTypeId;
            existingRoom.RoomNumber = request.RoomNumber;
            existingRoom.HotelId = request.HotelId;
            existingRoom.Status = request.Status;
            existingRoom.PricePerNight = request.PricePerNight;

            return await _repository.UpdateAsync(existingRoom);
        }
    }
}
