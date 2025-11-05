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
        private readonly IApplicationDbContext dbContext;

        public RoomRepository(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> AddAsync(Room room)
        {
            await dbContext.Rooms.AddAsync(room);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var room = await dbContext.Rooms.FindAsync(id);
            if(room != null)
            {
                dbContext.Rooms.Remove(room);
                return await dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<List<Room>> GetAllAsync()
        {
            var rooms = await dbContext.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            var room = await dbContext.Rooms.FindAsync(id);
            return room;
        }

        public async Task<int> UpdateAsync(int id, Room room)
        {
            var existingRoom = await dbContext.Rooms.FindAsync(id);
            if (existingRoom != null) 
            {
                existingRoom.RoomNumber = room.RoomNumber;
                existingRoom.Status = room.Status;
                existingRoom.PricePerNight = room.PricePerNight;
                existingRoom.HotelId = room.HotelId;
                existingRoom.RoomTypeId = room.RoomTypeId;
                return await dbContext.SaveChangesAsync();
            }
            return 0;
        }

        
    }
}
