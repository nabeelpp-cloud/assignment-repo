using GrandHayath.HotelBooking.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Infrastructure.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Booking> Bookings { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Hotel> Hotels { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<RoomType> RoomTypes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}