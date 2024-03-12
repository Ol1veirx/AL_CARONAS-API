using AL_CARONAS.Application.Services.Interfaces;
using AL_CARONAS.Core.Entities;
using AL_CARONAS_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AL_CARONAS_API.Controllers
{
    [ApiController]
    [Route("api/review")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _service;
        public ReviewController(IReviewService service)
        {
            _service = service;
        }

        [HttpGet("{targerUserId}")]
        public async Task<ActionResult<ICollection<Review>>> GetAllById(int targerUserId)
        {
            try
            {
                var reviewUser = await _service.GetAllByIdAsync(targerUserId);

                if (reviewUser == null) return NotFound();

                var reviewDtos = reviewUser.Select(reviewUser => new ReviewDto
                {
                    Comment = reviewUser.Comment,
                    Rating = reviewUser.Rating,
                    Date = reviewUser.Date
                });

                return Ok(reviewDtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Review>> CreateReview(Review review)
        {
            try
            {
                var newReview = await _service.CreateReviewAsync(review);

                if (newReview == null) return BadRequest();

                return Ok(newReview);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{reviewId}")]
        public async Task<ActionResult<Review>> UpdateReview(int reviewId,Review review)
        {
            if (reviewId != review.ReviewId) return NotFound();
            
            try
            {
                var updateReview = await _service.UpdateReviewAsync(review);

                if (updateReview == null) return BadRequest();

                return Ok(updateReview);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{reviewId}")]
        public async Task<ActionResult> DeleteReview(int reviewId)
        {
            try
            {
                var result = await _service.DeleteReviewAsync(reviewId);

                if (!result) return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
