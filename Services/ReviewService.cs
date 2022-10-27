using Microsoft.AspNetCore.Mvc;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public class ReviewService : IReviewService {
        public async Task<IActionResult> addreview(string Username, ReviewModifyModel reviewModifyModel, ApplicationDbContext db) {
            User? user = db.Users.Where(x => x.Username == Username).FirstOrDefault();
            if (user == null) { throw new KeyNotFoundException(); }
            Review review = new Review(reviewModifyModel, user);

            await db.Reviews.AddAsync(review);
            await db.SaveChangesAsync();
            return new OkResult();
        }

        public Task<IActionResult> deletereview(Guid ReviewId, ApplicationDbContext db) {
            throw new NotImplementedException();
        }

        public Task<IActionResult> editreview(Guid ReviewId, ReviewModifyModel reviewModifyModel, ApplicationDbContext db) {
            throw new NotImplementedException();
        }

        public List<ReviewModel> getreviewmodels(Guid MovieId, ApplicationDbContext db) {
            throw new NotImplementedException();
        }

        public List<ReviewShortModel> getreviewshortmodels(Guid MovieId, ApplicationDbContext db) {
            throw new NotImplementedException();
        }
    }
}
