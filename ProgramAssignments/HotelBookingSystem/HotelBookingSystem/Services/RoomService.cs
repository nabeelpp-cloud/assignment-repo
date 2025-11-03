using HotelBookingSystem.DTOs;
using HotelBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services
{
    public interface IRoomService
    {
        public Task<string> CreateRoom(Room room);
        public Task<string> UpdateRoom(int id, RoomDto roomDto);
        public Task<string> RemoveRoom(int id);
        public Task<Room> GetRoom(int id);
        public Task<List<Room>> GetAllRooms();
    }
    public class RoomService : IRoomService
    {
        private readonly HotelManagementDbContext _context;
        public RoomService(HotelManagementDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            try
            {
                var resp = await _context.SaveChangesAsync();
                if (resp > 0)
                    return "Room created successfully";
            }
            catch(Exception e)
            {
                return "Error creating room";
            }
            return "Error creating room";


        }

        public async Task<List<Room>> GetAllRooms()
        {

            var resp = await _context.Rooms.ToListAsync();
            return resp;

        }

        public async Task<Room> GetRoom(int id)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x=>x.Id==id);
            return room;
        }

        public async Task<string> RemoveRoom(int id)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);
            if (room == null)
                return "Room NotFound";
            _context.Remove(room);
            int resp = await _context.SaveChangesAsync();
            if (resp > 0)
                return "Room deleted successfully";
            return "Error deleted Room";
        }

        public async Task<string> UpdateRoom(int id, RoomDto roomDto)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);
            if (room == null)
                return "Room NotFound";
            if (roomDto.RoomNumber != null)
                room.RoomNumber = roomDto.RoomNumber;
            if (roomDto.HotelId != room.HotelId)
                room.HotelId = roomDto.HotelId;
            if (roomDto.RoomTypeId != room.RoomTypeId)
                room.RoomTypeId = roomDto.RoomTypeId;
            if (!roomDto.Status.Equals(room.Status))
                room.Status = (HotelBookingSystem.Models.RoomStatus)roomDto.Status;
            if (roomDto.PricePerNight != room.PricePerNight)
                room.PricePerNight = roomDto.PricePerNight;
            int resp = await _context.SaveChangesAsync();
            if (resp > 0)
                return "Room updated successfully";
            return "Error updated Room";


        }
    }
}
