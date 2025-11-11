using GrandHayath.HotelBooking.Application.Dtos;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Hotels.Query
{
    public class GetHotelWithReviewsQuery  : IRequest<HotelWithReviewsDto?>
    {
        public int Id { get; set; } 
    }

}
