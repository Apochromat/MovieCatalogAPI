using Microsoft.AspNetCore.Mvc;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;
using webNET_Hits_backend_aspnet_project_1.Services;

namespace webNET_Hits_backend_aspnet_project_1.Controllers
{
    [ApiController]
    [Route("api/movie")]
    public class ReviewController : ControllerBase {

        private readonly ApplicationDbContext db;
        private readonly IReviewService _reviewService;
        private readonly ICacheService _cacheService;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(ApplicationDbContext context, IReviewService reviewService, ICacheService cacheService, ILogger<ReviewController> logger) {
            db = context;
            _reviewService = reviewService;
            _cacheService = cacheService;
            _logger = logger;
        }

    }
}