using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Hotels.Query
{
    public class GetHotelWithReviewsQueryHandler : IRequestHandler<GetHotelWithReviewsQuery, HotelWithReviewsDto?>
    {
        private readonly IApplicationDbContext _context;

        public GetHotelWithReviewsQueryHandler(IApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<HotelWithReviewsDto?> Handle(GetHotelWithReviewsQuery request, CancellationToken cancellationToken)
        {
            var hotel = await _context.Hotels
                .Include(h => h.Reviews)
                .ThenInclude(i=>i.Customer)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            HotelWithReviewsDto hotelWithReviewsDto = new HotelWithReviewsDto();
            if (hotel != null) 
            {
                hotelWithReviewsDto.Id=hotel.Id;
                hotelWithReviewsDto.Name=hotel.Name;
                List<ReviewDto> reviewsDtos = new List<ReviewDto>();
                foreach (var review in hotel.Reviews)
                {
                    reviewsDtos.Add(new ReviewDto
                    {
                        Id = review.Id,
                        HotelId = review.HotelId,
                        CustomerName = review.Customer.FullName,
                        Rating = review.Rating,
                        Comment = review.Comment,
                        ReviewDate = review.ReviewDate
                    });
                    Console.WriteLine(reviewsDtos);
                }
                hotelWithReviewsDto.Reviews = reviewsDtos;
                return hotelWithReviewsDto;
            }
            return null;
        }
    }

}
