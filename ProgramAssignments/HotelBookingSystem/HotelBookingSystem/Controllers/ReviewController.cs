using HotelBookingSystem.Models;
using HotelBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public IActionResult Add([FromQuery] int hotelId,
                                 [FromQuery] int customerId,
                                 [FromQuery] int rating,
                                 [FromQuery] string comment)
        {
            Review review = new Review
            {
                HotelId = hotelId,
                CustomerId = customerId,
                Rating = rating,
                Comment = comment,
                ReviewDate = DateTime.Now
            };

            var result = _reviewService.CreateReview(review);

            if (result.Contains("Error"))
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch]
        public IActionResult Update([FromQuery] int id,
                                    [FromQuery] int? hotelId,
                                    [FromQuery] int? customerId,
                                    [FromQuery] int? rating,
                                    [FromQuery] string? comment,
                                    [FromQuery] DateTime? reviewDate)
        {
            var result = _reviewService.UpdateReview(id, hotelId, customerId, rating, comment, reviewDate);

            if (result.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(result);

            if (result.Contains("Error", StringComparison.OrdinalIgnoreCase))
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var review = _reviewService.GetReview(id);
            if (review == null)
                return NotFound("Review not found");

            return Ok(review);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _reviewService.RemoveReview(id);

            if (result.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(result);

            if (result.Contains("Error", StringComparison.OrdinalIgnoreCase))
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var reviews = _reviewService.GetAllReviews();

            if (reviews == null || !reviews.Any())
                return NotFound("No reviews found");

            return Ok(reviews);
        }
    }
}
