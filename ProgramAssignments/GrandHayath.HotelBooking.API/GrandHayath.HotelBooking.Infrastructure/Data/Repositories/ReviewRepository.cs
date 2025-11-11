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
    public class ReviewRepository : IReviewRepository
    {
        private readonly IApplicationDbContext _context;

        public ReviewRepository(IApplicationDbContext _context)
        {
            this._context = _context;
        }


        public async Task<int> AddAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Review review)
        {
            _context.Reviews.Remove(review);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<int> UpdateAsync( Review review)
        {
            _context.Reviews.Update(review);
            return await _context.SaveChangesAsync();
        }
    }
}
