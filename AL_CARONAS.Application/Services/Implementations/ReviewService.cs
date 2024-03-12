using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_CARONAS.Application.Services.Interfaces;
using AL_CARONAS.Core.Entities;
using AL_CARONAS.Infraestructure.Repositories.Interfaces;

namespace AL_CARONAS.Application.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repository;
        public ReviewService(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Review>> GetAllByIdAsync(int targerUserId)
        {
            return await _repository.GetAllByIdAsync(targerUserId);
        }

        public async Task<Review> CreateReviewAsync(Review review)
        {
            return await _repository.CreateReviewAsync(review);
        }

        public async Task<Review> UpdateReviewAsync(Review review)
        {
            return await _repository.UpdateReviewAsync(review);   
        }

        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            return await _repository.DeleteReviewAsync(reviewId);
        }
    }
}
