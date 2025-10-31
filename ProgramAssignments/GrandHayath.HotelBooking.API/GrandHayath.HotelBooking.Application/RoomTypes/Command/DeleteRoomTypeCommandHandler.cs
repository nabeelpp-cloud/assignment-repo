using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.RoomTypes.Command
{
    public class DeleteRoomTypeCommandHandler : IRequestHandler<DeleteRoomTypeCommand, int>
    {
        private readonly ApplicationDbContext context;

        public DeleteRoomTypeCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Handle(DeleteRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var roomType=await context.RoomTypes.FirstOrDefaultAsync(x=>x.Id==request.Id);
            if (roomType == null)
                return 0;
            context.RoomTypes.Remove(roomType);
            var resp = await context.SaveChangesAsync();
            return resp;
        }
    }
}
