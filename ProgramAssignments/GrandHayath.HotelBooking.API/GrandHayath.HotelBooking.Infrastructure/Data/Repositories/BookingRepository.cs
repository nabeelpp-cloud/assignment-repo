using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Infrastructure.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IApplicationDbContext _context;

        public BookingRepository(IApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async Task<int> AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Booking booking)
        {
                _context.Bookings.Remove(booking);
                return await _context.SaveChangesAsync();
        }

        public async Task<List<Booking>> GetAllAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task<int> UpdateAsync( Booking booking)
        {
            _context.Bookings.Update(booking);
            return await _context.SaveChangesAsync();
        }
    }
}
