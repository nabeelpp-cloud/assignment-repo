using GrandHayath.HotelBooking.Application.Dtos;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Rooms.Query
{
    public class GetAllRoomsQuery : IRequest<List<RoomDto>>
    {
    }

    public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery,List<RoomDto>>{
        Task<List<RoomDto>> IRequestHandler<GetAllRoomsQuery, List<RoomDto>>.Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
