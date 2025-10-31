using HotelBookingSystem.DTOs;
using HotelBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services
{
    public interface IHotelService
    {
        public Task<string> AddHotel(Hotel hotel);
        public Task<string> UpdateHotel(int Id, HotelDto hotelDto);
        public Task<Hotel> GetById(int id);
        public Task<string> Delete(int id);
        public Task<List<Hotel>> ListAll();
    }
    public class HotelService : IHotelService
    {
        private readonly HotelManagementDbContext _context;

        public HotelService(HotelManagementDbContext hotelManagementDbContext)
        {
            _context = hotelManagementDbContext;
        }
        public async Task<string> AddHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            int resp = await _context.SaveChangesAsync();
            if (resp == 0)
                return null;
            return "New hotel added succesfully";
                
        }

        public async Task<string> UpdateHotel(int id, HotelDto hotelDto)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == id);
            if (hotel == null)
            {
                return "Hotel not found";
            }

            hotel.Name = hotelDto.Name ?? hotel.Name;
            hotel.Address = hotelDto.Address ?? hotel.Address;
            hotel.City = hotelDto.City ?? hotel.City;
            hotel.Country = hotelDto.Country ?? hotel.Country;
            hotel.PhoneNumber = hotelDto.PhoneNumber ?? hotel.PhoneNumber;

            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return "Hotel updated successfully";
            }
            return "Error updating hotel";
        }


        public async Task<Hotel> GetById(int id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == id);
            return hotel;
        }

        public async Task<string> Delete(int id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == id);
            if (hotel != null)
            {
                _context.Remove(hotel);
                var resp = await _context.SaveChangesAsync();
                if (resp != null)
                {
                    return "Hotel Deleted Successfully";
                }
                return "Error deleting hotel";
            }
            return "Hotel NotFound";
        }

        public async Task<List<Hotel>> ListAll()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        
    }
}
