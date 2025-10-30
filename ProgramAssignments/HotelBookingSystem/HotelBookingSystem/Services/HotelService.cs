using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{
    public interface IHotelService
    {
        public string AddHotel(Hotel hotel);
        public string UpdateHotel(int Id, Hotel hotel);
        public Hotel GetById(int id);
        public string Delete(int id);
        public List<Hotel> ListAll();
    }
    public class HotelService : IHotelService
    {
        private readonly HotelManagementDbContext _context;

        public HotelService(HotelManagementDbContext hotelManagementDbContext)
        {
            _context = hotelManagementDbContext;
        }
        public string AddHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            int resp = _context.SaveChanges();
            if (resp == 0)
                return null;
            return "New hotel added succesfully";
                
        }

        public string UpdateHotel(int id,Hotel hotel)
        {
            var hotels = _context.Hotels.FirstOrDefault(x => x.Id == id);
            if (hotels == null)
            {
                return "Hotel NotFound";
            }
            hotels.Name = hotel.Name ?? hotels.Name;
            hotels.Address = hotel.Address ?? hotels.Address;
            hotels.City = hotel.City ?? hotels.City;
            hotels.Country = hotel.Country ?? hotels.Country;
            hotels.PhoneNumber = hotel.PhoneNumber ?? hotels.PhoneNumber;
            int resp =_context.SaveChanges();
            if(resp>0)
            {
                return "Hotel Updated Succesfully";
            }
            return "Error updating Hotel";

        }

        public Hotel GetById(int id)
        {
            var hotel = _context.Hotels.FirstOrDefault(x => x.Id == id);
            return hotel;
        }

        public string Delete(int id)
        {
            var hotel = _context.Hotels.FirstOrDefault(x => x.Id == id);
            if (hotel != null)
            {
                _context.Remove(hotel);
                var resp = _context.SaveChanges();
                if (resp != null)
                {
                    return "Hotel Deleted Successfully";
                }
                return "Error deleting hotel";
            }
            return "Hotel NotFound";
        }

        public List<Hotel> ListAll()
        {
            var hotels= _context.Hotels.ToList();
            return hotels;
        }

        
    }
}
