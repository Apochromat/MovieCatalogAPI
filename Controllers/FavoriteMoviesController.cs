using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize]
        [Route("")]
        public async Task<ActionResult<MoviesListModel>> GetFavorites() {
            try {
                // Logout checking
                if (await _cacheService.IsTokenDead(Request.Headers["Authorization"])) return Unauthorized("Token is expired");

                MoviesListModel moviesListModel = _favoriteMoviesService.getfavorites(User.Identity.Name, db);
                _logger.LogInformation($"Succesful getting of {User.Identity.Name}'s favorites");

                return moviesListModel;

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        [HttpPost]
        [Authorize]
        [Route("{movieId}/add")]
        public async Task<ActionResult> AddFavorites(Guid movieId) {
            try {
                // Logout checking
                if (await _cacheService.IsTokenDead(Request.Headers["Authorization"])) return Unauthorized("Token is expired");

                await _favoriteMoviesService.addfavorites(User.Identity.Name, movieId, db);
                _logger.LogInformation($"Succesful adding to {User.Identity.Name}'s favorites: {movieId}");

                return Ok();

                // TODO: Отлов, если фильм есть
            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("{movieId}/delete")]
        public async Task<ActionResult> DeleteFavorites(Guid movieId) {
            try {
                // Logout checking
                if (await _cacheService.IsTokenDead(Request.Headers["Authorization"])) return Unauthorized("Token is expired");

                await _favoriteMoviesService.deletefavorites(User.Identity.Name, movieId, db);
                _logger.LogInformation($"Succesful deleting from {User.Identity.Name}'s favorites: {movieId}");

                return Ok();
                // TODO: Отлов, если фильма нет
            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }
    }
}