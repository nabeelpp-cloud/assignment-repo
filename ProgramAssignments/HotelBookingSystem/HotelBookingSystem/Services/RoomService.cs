using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{
    public interface IRoomService
    {
        public string CreateRoom(Room room);
        public string UpdateRoom(int id, string? roomNumber, int? hotelId, int? roomTypeId, RoomStatus? status, decimal? pricePerNight);
        public string RemoveRoom(int id);
        public Room GetRoom(int id);
        public List<Room> GetAllRooms();
    }
    public class RoomService : IRoomService
    {
        private readonly HotelManagementDbContext _context;
        public RoomService(HotelManagementDbContext context)
        {
            _context = context;
        }

        public string CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            try
            {
                var resp = _context.SaveChanges();
                if (resp > 0)
                    return "Room created successfully";
            }
            catch(Exception e)
            {
                return "Error creating room";
            }
            return "Error creating room";


        }

        public List<Room> GetAllRooms()
        {

            var resp = _context.Rooms.ToList();
            return resp;

        }

        public Room GetRoom(int id)
        {
            var room = _context.Rooms.FirstOrDefault(x=>x.Id==id);
            return room;
        }

        public string RemoveRoom(int id)
        {
            var room = _context.Rooms.FirstOrDefault(x => x.Id == id);
            if (room == null)
                return "Room NotFound";
            _context.Remove(room);
            int resp = _context.SaveChanges();
            if (resp > 0)
                return "Room deleted successfully";
            return "Error deleted Room";
        }

        public string UpdateRoom(int id, string? roomNumber, int? hotelId, int? roomTypeId, RoomStatus? status, decimal? pricePerNight)
        {
            var room = _context.Rooms.FirstOrDefault(x => x.Id == id);
            if (room == null)
                return "Room NotFound";
            if (roomNumber != null)
                room.RoomNumber = roomNumber;
            if (hotelId.HasValue)
                room.HotelId = hotelId.Value;
            if (roomTypeId.HasValue)
                room.RoomTypeId = roomTypeId.Value;
            if (status.HasValue)
                room.Status = status.Value;
            if (pricePerNight.HasValue)
                room.PricePerNight = pricePerNight.Value;
            int resp = _context.SaveChanges();
            if (resp > 0)
                return "Room updated successfully";
            return "Error updated Room";


        }
    }
}
