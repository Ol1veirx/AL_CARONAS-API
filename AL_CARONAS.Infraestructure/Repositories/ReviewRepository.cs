using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_CARONAS.Core.Entities;
using AL_CARONAS.Infraestructure.Persistence;
using AL_CARONAS.Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AL_CARONAS.Infraestructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApiDbContext _context;
        public ReviewRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Review>> GetAllByIdAsync(int targerUserId)
        {
            var reviewUser = await _context.Reviews
                                            .Where(c => c.TargerUserId == targerUserId)
                                            .ToListAsync();
            return reviewUser;
           
        }

        public async Task<Review> CreateReviewAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return review;
        }

        public async Task<Review> UpdateReviewAsync(Review review)
        {
            var reviewExisting = await _context.Reviews.FindAsync(review.ReviewId);

            if (reviewExisting == null) return null;

            reviewExisting.Comment = review.Comment;
            reviewExisting.Rating = review.Rating;
            reviewExisting.Date = DateTime.Now;
            await _context.SaveChangesAsync();

            return reviewExisting;
        }

        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            var result = await _context.Reviews.FindAsync(reviewId);

            if (result == null) return false;

            _context.Reviews.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
