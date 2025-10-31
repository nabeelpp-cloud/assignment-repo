using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.RoomTypes.Query
{
    public class GetRoomTypeByIdQueryHandler : IRequestHandler<GetRoomTypeByIdQuery, RoomType>
    {
        private readonly ApplicationDbContext context;

        public GetRoomTypeByIdQueryHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<RoomType> Handle(GetRoomTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var response =await context.RoomTypes.FirstOrDefaultAsync(x=>x.Id==request.Id);
            return response;
        }
    }
}
