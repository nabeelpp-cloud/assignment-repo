using GrandHayath.HotelBooking.Application.Dtos;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Hotels.Query
{
    public class GetHotelFullDetailsQuery : IRequest<PaginatedHotelListDto>
    {
        public string? SearchTerm { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? StarRating { get; set; }
        public int MaxPrice { get; set; } = 1000;
        public int MinPrice { get; set; } = 0;
    }
}
