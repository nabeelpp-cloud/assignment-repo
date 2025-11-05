using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.RoomTypes.Command
{
    public class DeleteRoomTypeCommandHandler : IRequestHandler<DeleteRoomTypeCommand, int>
    {
        private readonly IRoomTypeRepository repository;

        public DeleteRoomTypeCommandHandler(IRoomTypeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> Handle(DeleteRoomTypeCommand request, CancellationToken cancellationToken)
        {
            return await repository.DeleteAsync(request.Id);
        }
    }
}
