using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public interface IReviewService {
        Task<IActionResult> addreview(String Username, ReviewModifyModel reviewModifyModel, ApplicationDbContext db);

        Task<IActionResult> editreview(Guid ReviewId, ReviewModifyModel reviewModifyModel, ApplicationDbContext db);

        Task<IActionResult> deletereview(Guid ReviewId, ApplicationDbContext db);

        List<ReviewModel> getreviewmodels(Guid MovieId, ApplicationDbContext db);

        List<ReviewShortModel> getreviewshortmodels(Guid MovieId, ApplicationDbContext db);
    }
}
