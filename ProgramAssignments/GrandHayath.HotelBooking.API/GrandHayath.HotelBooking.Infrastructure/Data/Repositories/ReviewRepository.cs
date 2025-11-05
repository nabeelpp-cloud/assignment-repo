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
    internal class ReviewRepository : IReviewRepository
    {
        private readonly IApplicationDbContext context;

        public ReviewRepository(IApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<int> AddAsync(Review review)
        {
            await context.Reviews.AddAsync(review);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var review = await context.Reviews.FindAsync(id);
            if (review != null)
            {
                context.Reviews.Remove(review);
                return await context.SaveChangesAsync();
            }

            return 0;

        }

        public async Task<List<Review>> GetAllAsync()
        {
            var reviews =await context.Reviews.ToListAsync();
            return reviews;
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            var review =await context.Reviews.FindAsync(id);
            return review;
        }

        public async Task<int> UpdateAsync(int id, Review review)
        {
            var existingReview = await context.Reviews.FindAsync(id);
            if(existingReview != null)
            {
                existingReview.HotelId = review.HotelId;
                existingReview.CustomerId = review.CustomerId;
                existingReview.Rating = review.Rating;
                existingReview.Comment = review.Comment;
                existingReview.ReviewDate = review.ReviewDate;
                return await context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
