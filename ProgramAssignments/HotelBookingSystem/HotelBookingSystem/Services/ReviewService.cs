using HotelBookingSystem.DTOs;
using HotelBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services
{
    public interface IReviewService
    {
        public Task<string> CreateReview(Review review);
        public Task<string> UpdateReview(int id, ReviewDto reviewDto);
        public Task<string> RemoveReview(int id);
        public Task<Review> GetReview(int id);
        public Task<List<Review>> GetAllReviews();
    }

    public class ReviewService : IReviewService
    {
        private readonly HotelManagementDbContext _context;

        public ReviewService(HotelManagementDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateReview(Review review)
        {
            await _context.Reviews.AddAsync(review);
            int result =await _context.SaveChangesAsync();

            return result > 0 ? "Review created successfully" : "Error creating review";
        }

        public async Task<string> UpdateReview(int id, ReviewDto reviewDto)
        {
            var review =await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
            if (review == null) return "Review not found";

            if (reviewDto.HotelId != review.HotelId) review.HotelId = reviewDto.HotelId;
            if (reviewDto.CustomerId != review.CustomerId) review.CustomerId = reviewDto.CustomerId;
            if (reviewDto.Rating != review.Rating) review.Rating = reviewDto.Rating;
            if (!string.IsNullOrEmpty(reviewDto.Comment)) review.Comment = reviewDto.Comment;
            if (reviewDto.ReviewDate != review.ReviewDate) review.ReviewDate = reviewDto.ReviewDate;

            int result =await _context.SaveChangesAsync();
            return result > 0 ? "Review updated successfully" : "Error updating review";
        }

        public async Task<string> RemoveReview(int id)
        {
            var review =await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
            if (review == null) return "Review not found";

            _context.Reviews.Remove(review);
            int result = _context.SaveChanges();

            return result > 0 ? "Review deleted successfully" : "Error deleting review";
        }

        public async Task<Review> GetReview(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Review>> GetAllReviews()
        {
            return await _context.Reviews.ToListAsync();
        }
    }
}
