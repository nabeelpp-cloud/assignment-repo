using GrandHayath.HotelBooking.Domain.Interfaces;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Rooms.Command
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, int>
    {
        private readonly IRoomRepository roomRepository;

        public DeleteRoomCommandHandler(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        public async Task<int> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            return await roomRepository.DeleteAsync(request.Id);
        }
    }
}
