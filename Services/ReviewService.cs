using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public class ReviewService : IReviewService {
        public async Task<IActionResult> addreview(string Username, Guid MovieId, ReviewModifyModel reviewModifyModel, ApplicationDbContext db) {
            User? user = db.Users.Where(x => x.Username == Username).FirstOrDefault();
            if (user == null) { throw new KeyNotFoundException("User not found"); }

            Movie? movie = db.Movies.Where(x => x.MovieId == MovieId).Include(x => x.Reviews).ThenInclude(x => x.User).FirstOrDefault();
            if (movie == null) { throw new KeyNotFoundException("Movie not found"); }

            Review? again = movie.Reviews.Where(x => x.User.Username == Username).FirstOrDefault();
            if (again != null) { throw new ArgumentException("Review already exists"); }

            Review review = new Review(reviewModifyModel, user);

            movie.Reviews.Add(review);
            db.Entry(review).State = EntityState.Added;
            db.Entry(movie).State = EntityState.Modified;
            
            await db.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IActionResult> deletereview(Guid ReviewId, ApplicationDbContext db) {
            Review? review = db.Reviews.Where(x => x.ReviewId == ReviewId).FirstOrDefault();
            if (review == null) { throw new KeyNotFoundException(); }

            db.Reviews.Remove(review);
            await db.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<IActionResult> editreview(Guid ReviewId, ReviewModifyModel reviewModifyModel, ApplicationDbContext db) {
            Review? review = db.Reviews.Where(x => x.ReviewId == ReviewId).FirstOrDefault();
            if (review == null) { throw new KeyNotFoundException(); }

            db.Attach(review);
            review.Modify(reviewModifyModel);

            await db.SaveChangesAsync();
            return new OkResult();
        }

        public List<ReviewModel> getreviewmodels(Guid MovieId, ApplicationDbContext db) {
            Movie? movie = db.Movies.Where(x => x.MovieId == MovieId).Include(x => x.Reviews).FirstOrDefault();
            if (movie == null) { throw new KeyNotFoundException("Movie not found"); }

            return movie.Reviews.Select(x => new ReviewModel(x)).ToList();
        }

        public List<ReviewShortModel> getreviewshortmodels(Guid MovieId, ApplicationDbContext db) {
            Movie? movie = db.Movies.Where(x => x.MovieId == MovieId).Include(x => x.Reviews).FirstOrDefault();
            if (movie == null) { throw new KeyNotFoundException("Movie not found"); }

            return movie.Reviews.Select(x => new ReviewShortModel(x)).ToList();
        }
    }
}
