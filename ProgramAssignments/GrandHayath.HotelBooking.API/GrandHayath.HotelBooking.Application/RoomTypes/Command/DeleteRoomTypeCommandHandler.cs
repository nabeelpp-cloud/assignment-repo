using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.RoomTypes.Command
{
    public class DeleteRoomTypeCommandHandler : IRequestHandler<DeleteRoomTypeCommand, int>
    {
        private readonly IRoomTypeRepository _repository;

        public DeleteRoomTypeCommandHandler(IRoomTypeRepository _repository)
        {
            this._repository = _repository;
        }
        public async Task<int> Handle(DeleteRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var roomType = await _repository.GetByIdAsync(request.Id);
            if (roomType == null)
            {
                return 0;
            }

            return await _repository.DeleteAsync(roomType);
        }
    }
}
