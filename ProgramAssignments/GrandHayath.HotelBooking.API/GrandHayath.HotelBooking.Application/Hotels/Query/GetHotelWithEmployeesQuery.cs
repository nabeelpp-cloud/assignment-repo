using GrandHayath.HotelBooking.Application.Dtos;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Hotels.Query
{
    public class GetHotelWithEmployeesQuery  : IRequest<HotelWithEmployeesDto?>
    {
        public int Id { get; set; } 
    }

}
