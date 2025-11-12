using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Hotels.Query
{
    public class GetHotelFullDetailsQueryHandler : IRequestHandler<GetHotelFullDetailsQuery, PaginatedHotelListDto>
    {
        private readonly IApplicationDbContext _context;

        public GetHotelFullDetailsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedHotelListDto> Handle(GetHotelFullDetailsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Hotels
                    .Include(h => h.HotelImages)
                    .Include(h => h.Reviews)
                        .ThenInclude(r => r.Customer)
                    .Include(h => h.Rooms)
                        .ThenInclude(r => r.Bookings)
                    .Include(h => h.Rooms)
                        .ThenInclude(r => r.RoomType)
                    .AsQueryable();



            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(h =>
                    h.Address.Contains(request.SearchTerm) ||
                    h.Country.Contains(request.SearchTerm) ||
                    h.City.Contains(request.SearchTerm));
            }

            if (request.CheckInDate.HasValue && request.CheckOutDate.HasValue)
            {
                var checkIn = request.CheckInDate.Value;
                var checkOut = request.CheckOutDate.Value;

                query = query.Where(h =>
                    h.Rooms.Any(r =>
                        !r.Bookings.Any(b =>
                            (b.CheckInDate < checkOut && b.CheckOutDate > checkIn))));
            }

            if (request.StarRating!=null)
            {
                var starRatings = request.StarRating
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                query = query.Where(h => starRatings.Contains(h.StarRating));
            }
            if (request.MinPrice > 0)
            {
                query = query.Where(h => h.Rooms.Any(r => r.PricePerNight >= request.MinPrice));
            }
            if (request.MaxPrice > 0)
            {
                query = query.Where(h => h.Rooms.Any(r => r.PricePerNight <= request.MaxPrice));
            }


            var totalCount = await query.CountAsync(cancellationToken);

            var hotels = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var hotelsDto = hotels.Select(h => new HotelFullDetailsDto
            {
                Id = h.Id,
                Name = h.Name,
                Address = h.Address,
                City = h.City,
                Country = h.Country,
                PhoneNumber = h.PhoneNumber,
                MinimumPrice = h.Rooms.Min(m => m.PricePerNight),
                MaximumPrice = h.Rooms.Max(m => m.PricePerNight),
                StarRating = h.StarRating,
                Rating = h.Reviews.Any()
                        ? Math.Round(h.Reviews.Average(m => (double)m.Rating) * 2, 1)
                        : 0,

                HotelImages = h.HotelImages.Select(m => new HotelImagesDto
                {
                    Id = m.Id,
                    ImageUrl = m.ImageUrl
                }).ToList(),
                Reviews = h.Reviews.Select(n => new ReviewDto
                {
                    Id = n.Id,
                    CustomerName = n.Customer != null ? n.Customer.FullName : "Anonymous",
                    Rating = n.Rating,
                    Comment = n.Comment,
                    ReviewDate = n.ReviewDate
                }).ToList(),
                Rooms = h.Rooms.Select(r => new RoomDto
                {
                    Id = r.Id,
                    RoomNumber = r.RoomNumber,
                    RoomType = r.RoomType.TypeName,
                    PricePerNight = r.PricePerNight
                }).ToList()
            }).ToList();

            return new PaginatedHotelListDto
            {
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize),
                Hotels = hotelsDto
            };
        }
    }
}
