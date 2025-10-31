using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;

namespace GrandHayath.HotelBooking.Application.RoomTypes.Command
{
    public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, int>
    {
        private readonly ApplicationDbContext context;

        public UpdateRoomTypeCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var roomType = context.RoomTypes.Find(request.Id);
            if (roomType == null)
                return 0;
            if(request.TypeName!=null)
                roomType.TypeName = request.TypeName;
            if(request.Description!=null) 
                roomType.Description = request.Description;
            if(request.Capacity.HasValue)
                roomType.Capacity = request.Capacity.Value;
            var resp = await context.SaveChangesAsync();
            return resp;
        }
    }
}
