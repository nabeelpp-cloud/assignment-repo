using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Infrastructure.Data.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IApplicationDbContext _context;

        public HotelRepository(IApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async Task<int> AddAsync(Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Hotel hotel)
        {

            _context.Hotels.Remove(hotel);
            return await _context.SaveChangesAsync();

        }

        public async Task<List<Hotel>> GetAllAsync()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel?> GetByIdAsync(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public async Task<int> UpdateAsync(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            return await _context.SaveChangesAsync();
        }
    }
}
