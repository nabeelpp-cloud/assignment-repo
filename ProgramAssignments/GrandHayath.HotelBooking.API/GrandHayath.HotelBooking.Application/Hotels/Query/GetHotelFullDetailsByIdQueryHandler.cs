using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Hotels.Query
{
    public class GetHotelFullDetailsByIdQueryHandler  : IRequestHandler<GetHotelFullDetailsByIdQuery, HotelFullDetailsDto>
    {
        private readonly IApplicationDbContext dbContext;

        public GetHotelFullDetailsByIdQueryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<HotelFullDetailsDto?> Handle(GetHotelFullDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var hotel = await dbContext.Hotels
                .Where(h => h.Id == request.Id)
                .Select(h => new
                {
                    Hotel = h,
                    Images = h.HotelImages.Select(i => new HotelImagesDto
                    {
                        Id = i.Id,
                        ImageUrl = i.ImageUrl
                    }).ToList(),

                    Reviews = h.Reviews.Select(r => new ReviewDto
                    {
                        Id = r.Id,
                        CustomerName = r.Customer != null ? r.Customer.FullName : "Anonymous",
                        Rating = r.Rating,
                        Comment = r.Comment,
                        ReviewDate = r.ReviewDate
                    }).ToList(),

                    Rooms = h.Rooms.Select(r => new
                    {
                        Room = r,
                        RoomType = r.RoomType,
                        Bookings = r.Bookings
                    }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (hotel == null)
                return null;

            List<Room> availableRooms;
            if (request.CheckInDate.HasValue && request.CheckOutDate.HasValue)
            {
                var checkIn = request.CheckInDate.Value;
                var checkOut = request.CheckOutDate.Value;

                availableRooms = hotel.Rooms
                    .Where(r =>
                        r.Room.Status != RoomStatus.UnderMaintenance &&                    
                        !r.Bookings.Any(b =>
                            b.CheckInDate < checkOut &&
                            b.CheckOutDate > checkIn))
                    .Select(r => r.Room)
                    .ToList();
            }
            else
            {
                availableRooms = hotel.Rooms
                    .Where(r => r.Room.Status != RoomStatus.UnderMaintenance)
                    .Select(r => r.Room)
                    .ToList();
            }

            return new HotelFullDetailsDto
            {
                Id = hotel.Hotel.Id,
                Name = hotel.Hotel.Name,
                Address = hotel.Hotel.Address,
                City = hotel.Hotel.City,
                Country = hotel.Hotel.Country,
                PhoneNumber = hotel.Hotel.PhoneNumber,

                MinimumPrice = availableRooms.Any() ? availableRooms.Min(r => r.PricePerNight) : 0,
                MaximumPrice = availableRooms.Any() ? availableRooms.Max(r => r.PricePerNight) : 0,

                StarRating = hotel.Hotel.StarRating,
                Rating = hotel.Reviews.Any() ? Math.Round(hotel.Reviews.Average(r => (double)r.Rating), 1) : 0,

                HotelImages = hotel.Images,
                Reviews = hotel.Reviews,

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
