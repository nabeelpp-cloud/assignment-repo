using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{
    public interface IRoomTypeService
    {
        public string AddRoomType(RoomType roomType);
        public string RemoveRoomType(int id);
        public RoomType GetRoomType(int id);
        public List<RoomType> GetAllRoomTypes();
        public string UpdateRoomType(int id, string? typeName, string? description, int? capacity);
    }
    public class RoomTypeService : IRoomTypeService
    {
        private readonly HotelManagementDbContext _context;

        public RoomTypeService(HotelManagementDbContext hotelManagementDbContext) 
        { 
            _context = hotelManagementDbContext;
        }

        public string AddRoomType(RoomType roomType)
        {
            _context.RoomTypes.Add(roomType);
            var resp = _context.SaveChanges();
            if (resp > 0)
                return "New room added";
            return "Error creating new room";
        }

        public List<RoomType> GetAllRoomTypes()
        {
            var roomTypes = _context.RoomTypes.ToList();
            return roomTypes;
        }

        public RoomType GetRoomType(int id)
        {
            var roomTypes = _context.RoomTypes.FirstOrDefault(x=>x.Id==id);
            return roomTypes;
        }

        public string RemoveRoomType(int id)
        {
            var roomTypes = _context.RoomTypes.FirstOrDefault(x => x.Id == id);
            if (roomTypes == null)
                return "RommeType NotFound";
            _context.RoomTypes.Remove(roomTypes);
            var resp = _context.SaveChanges();
            if (resp > 0)
                return "Rommtype removed successfully";
            return "Error deleting roomtype";
        }

        public string UpdateRoomType(int id,string? typeName,string? description,int? capacity)
        {
            var roomTypes = _context.RoomTypes.FirstOrDefault(x => x.Id == id);
            if (roomTypes == null)
                return "RommeType NotFound";
            if (typeName != null)
                roomTypes.TypeName = typeName;
            if (description != null)
                roomTypes.Description = description;
            if (capacity.HasValue)
                roomTypes.Capacity = capacity.Value;
            var resp = _context.SaveChanges();
            if (resp > 0)
                return "Romm type updated successfully";
            return "Error updating roomtype";

        }
    }
}
