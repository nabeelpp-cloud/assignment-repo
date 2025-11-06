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
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly IApplicationDbContext _context;

        public RoomTypeRepository(IApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async Task<int> AddAsync(RoomType roomType)
        {
            _context.RoomTypes.Add(roomType);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(RoomType roomType)
        {
                _context.RoomTypes.Remove(roomType);
            return await _context.SaveChangesAsync();
            
        }

        public async Task<List<RoomType>> GetAllAsync()
        {
            return await _context.RoomTypes.ToListAsync();
        }

        public async Task<RoomType?> GetByIdAsync(int id)
        {
            return await _context.RoomTypes.FindAsync(id);
        }

        public async Task<int> UpdateAsync(RoomType roomType)
        {
            _context.RoomTypes.Update(roomType);
            return await _context.SaveChangesAsync();
        }
    }
}
