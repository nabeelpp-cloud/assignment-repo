using GrandHayath.HotelBooking.Application.Dtos;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Hotels.Query
{
    public class GetAllHotelQuery : IRequest<List<HotelDto>>
    {

    }
}
