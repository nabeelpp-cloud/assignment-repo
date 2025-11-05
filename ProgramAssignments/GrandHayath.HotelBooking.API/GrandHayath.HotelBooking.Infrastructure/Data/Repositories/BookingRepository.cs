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
    internal class BookingRepository : IBookingRepository
    {
        private readonly IApplicationDbContext applicationDbContext;

        public BookingRepository(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> AddAsync(Booking booking)
        {
            await applicationDbContext.Bookings.AddAsync(booking);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var booking =await applicationDbContext.Bookings.FindAsync(id);
            if(booking!=null)
            {
                applicationDbContext.Bookings.Remove(booking);
                return await applicationDbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<List<Booking>> GetAllAsync()
        {
            var bookings = await applicationDbContext.Bookings.ToListAsync();
            return bookings;
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            var booking = await applicationDbContext.Bookings.FindAsync(id);
            return booking;
        }

        public async Task<int> UpdateAsync(int id, Booking booking)
        {
            var existingBooking = await applicationDbContext.Bookings.FindAsync(id);
            if (existingBooking != null)
            {
                existingBooking.CustomerId=booking.CustomerId;
                existingBooking.RoomId=booking.RoomId;
                existingBooking.CheckInDate=booking.CheckInDate;
                existingBooking.CheckOutDate=booking.CheckOutDate;
                existingBooking.TotalAmount=booking.TotalAmount;
                return await applicationDbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}
