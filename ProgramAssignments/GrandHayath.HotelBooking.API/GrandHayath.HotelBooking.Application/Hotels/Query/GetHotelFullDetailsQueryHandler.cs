using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Hotels.Query
{
    public class GetHotelFullDetailsQueryHandler
        : IRequestHandler<GetHotelFullDetailsQuery, PaginatedHotelListDto>
    {
        private readonly IApplicationDbContext _context;

        public GetHotelFullDetailsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedHotelListDto> Handle(
            GetHotelFullDetailsQuery request,
            CancellationToken cancellationToken)
        {
            DateTime? checkIn = request.CheckInDate;
            DateTime? checkOut = request.CheckOutDate;

            var query = _context.Hotels
                .Include(h => h.HotelImages)
                .Include(h => h.Reviews).ThenInclude(r => r.Customer)
                .Include(h => h.Rooms).ThenInclude(r => r.Bookings)
                .Include(h => h.Rooms).ThenInclude(r => r.RoomType)
                .Where(h => h.Rooms.Any(r => r.Status != RoomStatus.UnderMaintenance))
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.ToLower();

                query = query.Where(h =>
                    h.Address.ToLower().Contains(term) ||
                    h.City.ToLower().Contains(term) ||
                    h.Country.ToLower().Contains(term));
            }
            if (checkIn.HasValue && checkOut.HasValue)
            {
                query = query.Where(h =>
                    h.Rooms.Any(r =>
                        !r.Bookings.Any(b => b.CheckInDate < checkOut && b.CheckOutDate > checkIn)
                    )
                );
            }

            if (!string.IsNullOrWhiteSpace(request.StarRating))
            {
                var starRatings = request.StarRating
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                query = query.Where(h => starRatings.Contains(h.StarRating));
            }

            if ((request.MinPrice > 0 || request.MaxPrice > 0) && checkIn.HasValue && checkOut.HasValue)
            {
                query = query.Where(h =>
                    h.Rooms
                        .Where(r => !r.Bookings.Any(b => b.CheckInDate < checkOut && b.CheckOutDate > checkIn))
                        .Any(r =>
                            (request.MinPrice == 0 || r.PricePerNight >= request.MinPrice) &&
                            (request.MaxPrice == 0 || r.PricePerNight <= request.MaxPrice)
                        )
                );
            }
            else
            {
                if (request.MinPrice > 0)
                {
                    query = query.Where(h =>
                        h.Rooms.Any(r => r.PricePerNight >= request.MinPrice));
                }

                if (request.MaxPrice > 0)
                {
                    query = query.Where(h =>
                        h.Rooms.Any(r => r.PricePerNight <= request.MaxPrice));
                }
            }

            if (!string.IsNullOrWhiteSpace(request.SortBy))
            {
                if (request.SortBy == "priceLowToHigh")
                {
                    query = query.OrderBy(h => h.Rooms.Min(r => r.PricePerNight));
                }
                else if (request.SortBy == "priceHighToLow")
                {
                    query = query.OrderByDescending(h => h.Rooms.Max(r => r.PricePerNight));
                }
                else if (request.SortBy == "recomended")
                {
                    query = query.OrderByDescending(h =>
                        h.Reviews.Any()
                            ? Math.Round(h.Reviews.Average(r => (double)r.Rating) * 2, 1)
                            : 0
                    );
                }
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var hotels = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var hotelsDto = hotels.Select(h =>
            {
                var availableRooms = h.Rooms.Where(r =>
                    !r.Bookings.Any(b => checkIn.HasValue && checkOut.HasValue &&
                                         b.CheckInDate < checkOut && b.CheckOutDate > checkIn)
                );

                return new HotelFullListDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    Address = h.Address,
                    City = h.City,
                    Country = h.Country,
                    PhoneNumber = h.PhoneNumber,

                    MinimumPrice = availableRooms.Any()
                        ? availableRooms.Min(r => r.PricePerNight)
                        : 0,

                    MaximumPrice = availableRooms.Any()
                        ? availableRooms.Max(r => r.PricePerNight)
                        : 0,

                    StarRating = h.StarRating,

                    Rating = h.Reviews.Any()
                        ? Math.Round(h.Reviews.Average(r => (double)r.Rating) * 2, 1)
                        : 0,

                    HotelImages = h.HotelImages.Select(img => new HotelImagesDto
                    {
                        Id = img.Id,
                        ImageUrl = img.ImageUrl
                    }).ToList()
                };
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
