using Microsoft.AspNetCore.Mvc;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;
using webNET_Hits_backend_aspnet_project_1.Services;

namespace webNET_Hits_backend_aspnet_project_1.Controllers
{
    [ApiController]
    [Route("/api/favorites")]
    public class FavoriteMoviesController : ControllerBase {
        private readonly ApplicationDbContext db;
        private readonly IFavoriteMoviesService _favoriteMoviesService;
        private readonly ICacheService _cacheService;
        private readonly ILogger<FavoriteMoviesController> _logger;

        public FavoriteMoviesController(ApplicationDbContext context, IFavoriteMoviesService favoriteMoviesService, ICacheService cacheService, ILogger<FavoriteMoviesController> logger) {
            db = context;
            _favoriteMoviesService = favoriteMoviesService;
            _cacheService = cacheService;
            _logger = logger;
        }
    }
}