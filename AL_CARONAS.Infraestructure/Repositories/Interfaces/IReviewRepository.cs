using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_CARONAS.Core.Entities;

namespace AL_CARONAS.Infraestructure.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        Task<ICollection<Review>> GetAllByIdAsync(int userId);
        Task<Review> CreateReviewAsync(Review review);
        Task<Review> UpdateReviewAsync(Review review);
        Task<bool> DeleteReviewAsync(int reviewId);
    }
}
