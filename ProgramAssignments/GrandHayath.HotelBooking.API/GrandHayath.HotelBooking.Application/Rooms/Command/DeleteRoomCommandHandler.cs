using GrandHayath.HotelBooking.Domain.Interfaces;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Rooms.Command
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, int>
    {
        private readonly IRoomRepository _repository;

        public DeleteRoomCommandHandler(IRoomRepository _repository)
        {
            this._repository = _repository;
        }
        public async Task<int> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _repository.GetByIdAsync(request.Id);
            if (room == null)
            {
                return 0;
            }

            return await _repository.DeleteAsync(room);
        }
    }
}
