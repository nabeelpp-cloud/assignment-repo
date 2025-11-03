using HotelBookingSystem.DTOs;
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
        public async Task<IActionResult> Add(ReviewDto reviewDto)
        {
            Review review = new Review
            {
                HotelId = reviewDto.HotelId,
                CustomerId = reviewDto.CustomerId,
                Rating = reviewDto.Rating,
                Comment = reviewDto.Comment,
                ReviewDate = reviewDto.ReviewDate
            };

            var result =await _reviewService.CreateReview(review);

            if (result.Contains("Error"))
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async  Task<IActionResult> Update(int id , ReviewDto reviewDto)
        {

            var result =await _reviewService.UpdateReview(id,reviewDto);

            if (result.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(result);

            if (result.Contains("Error", StringComparison.OrdinalIgnoreCase))
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var review =await _reviewService.GetReview(id);
            if (review == null)
                return NotFound("Review not found");

            return Ok(review);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result =await _reviewService.RemoveReview(id);

            if (result.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(result);

            if (result.Contains("Error", StringComparison.OrdinalIgnoreCase))
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews =await _reviewService.GetAllReviews();

            if (reviews == null || !reviews.Any())
                return NotFound("No reviews found");

            return Ok(reviews);
        }
    }
}
