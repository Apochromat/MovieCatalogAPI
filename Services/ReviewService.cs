using Microsoft.AspNetCore.Mvc;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public class ReviewService : IReviewService {
        public Task<IActionResult> addreview(string Username, ReviewModifyModel reviewModifyModel, ApplicationDbContext db) {
            throw new NotImplementedException();
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
