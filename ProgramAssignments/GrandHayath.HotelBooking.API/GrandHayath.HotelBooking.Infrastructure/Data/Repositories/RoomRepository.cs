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
    public class RoomRepository : IRoomRepository
    {
        private readonly IApplicationDbContext _context;

        public RoomRepository(IApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async Task<int> AddAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Room room)
        {

            _context.Rooms.Remove(room);
            return await _context.SaveChangesAsync();

        }

        public async Task<List<Room>> GetAllAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<int> UpdateAsync( Room room)
        {
            _context.Rooms.Update(room);
            return await _context.SaveChangesAsync();
        }

    }
}
