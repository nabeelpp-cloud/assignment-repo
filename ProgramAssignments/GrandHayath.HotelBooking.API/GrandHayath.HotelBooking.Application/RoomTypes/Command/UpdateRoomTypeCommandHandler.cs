using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.RoomTypes.Command
{
    public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, int>
    {
        private readonly IRoomTypeRepository repository;

        public UpdateRoomTypeCommandHandler(IRoomTypeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var roomType = new RoomType
            {
                TypeName = request.TypeName,
                Description = request.Description,
                Capacity = request.Capacity
            };
            return await repository.UpdateAsync(request.Id, roomType);
        }
    }
}
