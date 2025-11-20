using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Hotels.Query
{
    public class GetHotelFullDetailsByIdQueryHandler
        : IRequestHandler<GetHotelFullDetailsByIdQuery, HotelFullDetailsDto>
    {
        private readonly IApplicationDbContext dbContext;

        public GetHotelFullDetailsByIdQueryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<HotelFullDetailsDto?> Handle(
            GetHotelFullDetailsByIdQuery request,
            CancellationToken cancellationToken)
        {
            var hotel = await dbContext.Hotels
                .Include(h => h.HotelImages)
                .Include(h => h.Reviews).ThenInclude(r => r.Customer)
                .Include(h => h.Rooms)
                    .ThenInclude(r => r.RoomType)
                .Include(h => h.Rooms)
                    .ThenInclude(r => r.Bookings)
                .FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

            if (hotel == null)
                return null;

            List<Room> availableRooms;

            if (request.CheckInDate.HasValue && request.CheckOutDate.HasValue)
            {
                var checkIn = request.CheckInDate.Value;
                var checkOut = request.CheckOutDate.Value;

                availableRooms = hotel.Rooms
                    .Where(r =>
                        r.Status != RoomStatus.UnderMaintenance &&
                        !r.Bookings.Any(b =>
                            b.CheckInDate < checkOut &&
                            b.CheckOutDate > checkIn
                        )
                    )
                    .ToList();
            }
            else
            {
                availableRooms = hotel.Rooms
                    .Where(r => r.Status != RoomStatus.UnderMaintenance)
                    .ToList();
            }

            var reviews = hotel.Reviews.Select(r => new ReviewDto
            {
                Id = r.Id,
                CustomerName = r.Customer != null ? r.Customer.FullName : "Anonymous",
                Rating = r.Rating,
                Comment = r.Comment,
                ReviewDate = r.ReviewDate
            }).ToList();

            return new HotelFullDetailsDto
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Address = hotel.Address,
                City = hotel.City,
                Country = hotel.Country,
                PhoneNumber = hotel.PhoneNumber,

                MinimumPrice = availableRooms.Any()
                    ? availableRooms.Min(r => r.PricePerNight)
                    : 0,

                MaximumPrice = availableRooms.Any()
                    ? availableRooms.Max(r => r.PricePerNight)
                    : 0,

                StarRating = hotel.StarRating,
                Rating = reviews.Any()
                    ? Math.Round(reviews.Average(r => (double)r.Rating), 1)
                    : 0,

                HotelImages = hotel.HotelImages.Select(i => new HotelImagesDto
                {
                    Id = i.Id,
                    ImageUrl = i.ImageUrl
                }).ToList(),

                Reviews = reviews,

                Rooms = availableRooms.Select(r => new RoomDto
                {
                    Id = r.Id,
                    RoomNumber = r.RoomNumber,
                    RoomType = r.RoomType.TypeName,
                    Description = r.RoomType.Description,
                    PricePerNight = r.PricePerNight
                }).ToList()
            };
        }
    }
}
