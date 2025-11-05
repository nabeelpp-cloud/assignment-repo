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
        private readonly IApplicationDbContext dbContext;

        public RoomTypeRepository(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> AddAsync(RoomType roomType)
        {
            dbContext.RoomTypes.Add(roomType);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var roomType=await dbContext.RoomTypes.FindAsync(id);
            if (roomType != null)
            {
                dbContext.RoomTypes.Remove(roomType);
                var resp = await dbContext.SaveChangesAsync();
                return resp;
            }
            return 0;
            
        }

        public async Task<List<RoomType>> GetAllAsync()
        {
            return await dbContext.RoomTypes.ToListAsync();
        }

        public async Task<RoomType?> GetByIdAsync(int id)
        {
            return await dbContext.RoomTypes.FindAsync(id);
        }

        public async Task<int> UpdateAsync(int id,RoomType roomType)
        {
            var existingRoomType = await dbContext.RoomTypes.FindAsync(id);
            if(existingRoomType != null)
            {
                existingRoomType.TypeName = roomType.TypeName;
                existingRoomType.Description = roomType.Description;
                existingRoomType.Capacity = roomType.Capacity;
                return await dbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}
