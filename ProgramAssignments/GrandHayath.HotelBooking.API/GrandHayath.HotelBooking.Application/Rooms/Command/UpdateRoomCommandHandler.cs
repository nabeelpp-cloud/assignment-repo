using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Rooms.Command
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, int>
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UpdateRoomCommandHandler(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await applicationDbContext.Rooms.FindAsync(request.Id, cancellationToken);
            if (room == null)
                return 0;
            if (request.RoomNumber != null)
                room.RoomNumber = request.RoomNumber;
            if (request.HotelId.HasValue)
                room.HotelId = request.HotelId.Value;
            if (request.RoomTypeId.HasValue)
                room.RoomTypeId = request.RoomTypeId.Value;
            if (request.Status.HasValue)
                room.Status = request.Status.Value;
            if (request.PricePerNight.HasValue)
                room.PricePerNight = request.PricePerNight.Value;
            var response = await applicationDbContext.SaveChangesAsync(cancellationToken);
            return response;
        }
    }
}
