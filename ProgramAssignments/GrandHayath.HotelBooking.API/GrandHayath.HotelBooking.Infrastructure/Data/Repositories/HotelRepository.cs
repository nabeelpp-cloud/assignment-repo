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
    public class HotelRepository : IHotelRepository
    {
        private readonly IApplicationDbContext applicationDbContext;

        public HotelRepository(IApplicationDbContext applicationDbContext) 
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> AddAsync(Hotel hotel)
        {
            await applicationDbContext.Hotels.AddAsync(hotel);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var hotel = await applicationDbContext.Hotels.FindAsync(id);
            if (hotel != null) 
            {
                applicationDbContext.Hotels.Remove(hotel);
                return await applicationDbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<List<Hotel>> GetAllAsync()
        {
            var hotels= await applicationDbContext.Hotels.ToListAsync ();
            return hotels;
        }

        public async Task<Hotel?> GetByIdAsync(int id)
        {
            var room = await applicationDbContext.Hotels.FindAsync (id);
            return room;
        }

        public async Task<int> UpdateAsync(int id, Hotel hotel)
        {
            var existingHotel = await applicationDbContext.Hotels.FindAsync(id);
            if (existingHotel != null)
            {
                existingHotel.Name = hotel.Name;
                existingHotel.Address = hotel.Address;
                existingHotel.City = hotel.City;
                existingHotel.Country = hotel.Country;
                existingHotel.PhoneNumber = hotel.PhoneNumber;
                return await applicationDbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}
