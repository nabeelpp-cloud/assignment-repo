using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{
    public interface IReviewService
    {
        string CreateReview(Review review);
        string UpdateReview(int id, int? hotelId, int? customerId, int? rating, string? comment, DateTime? reviewDate);
        string RemoveReview(int id);
        Review GetReview(int id);
        List<Review> GetAllReviews();
    }

    public class ReviewService : IReviewService
    {
        private readonly HotelManagementDbContext _context;

        public ReviewService(HotelManagementDbContext context)
        {
            _context = context;
        }

        public string CreateReview(Review review)
        {
            _context.Reviews.Add(review);
            int result = _context.SaveChanges();

            return result > 0 ? "Review created successfully" : "Error creating review";
        }

        public string UpdateReview(int id, int? hotelId, int? customerId, int? rating, string? comment, DateTime? reviewDate)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.Id == id);
            if (review == null) return "Review not found";

            if (hotelId.HasValue) review.HotelId = hotelId.Value;
            if (customerId.HasValue) review.CustomerId = customerId.Value;
            if (rating.HasValue) review.Rating = rating.Value;
            if (!string.IsNullOrEmpty(comment)) review.Comment = comment;
            if (reviewDate.HasValue) review.ReviewDate = reviewDate.Value;

            int result = _context.SaveChanges();
            return result > 0 ? "Review updated successfully" : "Error updating review";
        }

        public string RemoveReview(int id)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.Id == id);
            if (review == null) return "Review not found";

            _context.Reviews.Remove(review);
            int result = _context.SaveChanges();

            return result > 0 ? "Review deleted successfully" : "Error deleting review";
        }

        public Review GetReview(int id)
        {
            return _context.Reviews.FirstOrDefault(r => r.Id == id);
        }

        public List<Review> GetAllReviews()
        {
            return _context.Reviews.ToList();
        }
    }
}
