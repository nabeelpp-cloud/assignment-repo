using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Rooms.Command
{
    public class CreateRoomCommandHandler  : IRequestHandler<CreateRoomCommand, int>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CreateRoomCommandHandler(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            Room room = new Room();
            room.RoomNumber = request.RoomNumber;
            room.HotelId = request.HotelId;
            room.RoomTypeId = request.RoomTypeId;
            room.Status = request.Status;
            room.PricePerNight = request.PricePerNight;
            await applicationDbContext.Rooms.AddAsync(room);
            var response = await applicationDbContext.SaveChangesAsync(cancellationToken);
            return response;
        }
    }
}
