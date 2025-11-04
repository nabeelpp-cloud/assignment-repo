using HotelBookingSystem.DTOs;
using HotelBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services
{
    public interface IRoomTypeService
    {
        public Task<string> AddRoomType(RoomType roomType);
        public Task<string> RemoveRoomType(int id);
        public Task<RoomType> GetRoomType(int id);
        public Task<List<RoomType>> GetAllRoomTypes();
        public Task<string> UpdateRoomType(int id, RoomTypeDto roomTypeDto);
    }
    public class RoomTypeService : IRoomTypeService
    {
        private readonly HotelManagementDbContext _context;

        public RoomTypeService(HotelManagementDbContext hotelManagementDbContext) 
        { 
            _context = hotelManagementDbContext;
        }

        public async Task<string> AddRoomType(RoomType roomType)
        {
            _context.RoomTypes.Add(roomType);
            var resp = await _context.SaveChangesAsync();
            if (resp > 0)
                return "New room added";
            return "Error creating new room";
        }

        public async Task<List<RoomType>> GetAllRoomTypes()
        {
            var roomTypes = await _context.RoomTypes.ToListAsync();
            return roomTypes;
        }

        public async Task<RoomType> GetRoomType(int id)
        {
            var roomTypes = await _context.RoomTypes.FirstOrDefaultAsync(x=>x.Id==id);
            return roomTypes;
        }

        public async Task<string> RemoveRoomType(int id)
        {
            var roomTypes = await _context.RoomTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (roomTypes == null)
                return "RoomType NotFound";
            _context.RoomTypes.Remove(roomTypes);
            var resp = await _context.SaveChangesAsync();
            if (resp > 0)
                return "RoomType removed successfully";
            return "Error deleting RoomType";
        }

        public async Task<string> UpdateRoomType(int id, RoomTypeDto roomTypeDto)
        {
            var roomTypes = await _context.RoomTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (roomTypes == null)
                return "RoomType NotFound";
            if (roomTypeDto.TypeName != null)
                roomTypes.TypeName = roomTypeDto.TypeName;
            if (roomTypeDto.Description != null)
                roomTypes.Description = roomTypeDto.Description;
            if (roomTypeDto.Capacity != roomTypes.Capacity)
                roomTypes.Capacity = roomTypeDto.Capacity;
            var resp = await _context.SaveChangesAsync();
            if (resp > 0)
                return "Room type updated successfully";
            return "Error updating RoomType";

        }
    }
}
