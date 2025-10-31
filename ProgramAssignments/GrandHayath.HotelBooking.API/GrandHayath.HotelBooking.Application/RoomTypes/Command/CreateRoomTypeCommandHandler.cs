using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using GrandHayath.HotelBooking.Domain.Entity;

namespace GrandHayath.HotelBooking.Application.RoomTypes.Command
{
    public class CreateRoomTypeCommandHandler : IRequestHandler<CreateRoomTypeCommand, int>
    {
        private readonly ApplicationDbContext context;

        public CreateRoomTypeCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(CreateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            RoomType roomType = new RoomType();
            roomType.TypeName = request.TypeName;
            roomType.Description = request.Description;
            roomType.Capacity = request.Capacity;
            await context.RoomTypes.AddAsync(roomType);
            var resp=await context.SaveChangesAsync();
            return resp;
        }
    }
}
