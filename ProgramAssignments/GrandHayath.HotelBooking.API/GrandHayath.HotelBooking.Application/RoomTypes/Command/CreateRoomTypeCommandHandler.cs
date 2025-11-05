using MediatR;
using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;

namespace GrandHayath.HotelBooking.Application.RoomTypes.Command
{
    public class CreateRoomTypeCommandHandler : IRequestHandler<CreateRoomTypeCommand, int>
    {
        private readonly IRoomTypeRepository repository;

        public CreateRoomTypeCommandHandler(IRoomTypeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var roomType = new RoomType
            {
                TypeName = request.TypeName,
                Description = request.Description,
                Capacity = request.Capacity
            };

            return await repository.AddAsync(roomType);
        }
    }
}
