using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Rooms.Command
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, int>
    {
        private readonly ApplicationDbContext applicationDbContext;
        public DeleteRoomCommandHandler(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await applicationDbContext.Rooms.FindAsync(request.Id, cancellationToken);
            if (room != null)
            {
                applicationDbContext.Rooms.Remove(room);
                var response = await applicationDbContext.SaveChangesAsync(cancellationToken);
                return response;
            }
            return 0;
        }
    }
}
