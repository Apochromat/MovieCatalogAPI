using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;
using webNET_Hits_backend_aspnet_project_1.Services;

namespace webNET_Hits_backend_aspnet_project_1.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenreController : ControllerBase {
        private readonly ApplicationDbContext db;
        private readonly IGenreService _genreService;
        private readonly ICacheService _cacheService;
        private readonly ILogger<GenreController> _logger;

        public GenreController(ApplicationDbContext context, IGenreService genreService, ICacheService cacheService, ILogger<GenreController> logger) {
            db = context;
            _genreService = genreService;
            _cacheService = cacheService;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<GenreModel>>> GetGenres() {
            try {
                var genreModels = _genreService.getgenres(db);
                return Ok(genreModels);

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("add")]
        public async Task<ActionResult> AddGenre([FromBody] GenreModel genreModel) {
            try {
                // Logout checking
                if (await _cacheService.IsTokenDead(Request.Headers["Authorization"])) return Unauthorized("Token is expired");

                await _genreService.creategenre(genreModel, db);
                return Ok();

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }


        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("delete/{id}")]
        public async Task<ActionResult> DeleteGenre(Guid id) {
            try {
                // Logout checking
                if (await _cacheService.IsTokenDead(Request.Headers["Authorization"])) return Unauthorized("Token is expired");

                await _genreService.deletegenre(id, db);
                return Ok();

            } catch (ArgumentNullException e) {
                // Catch if genre was not found in database
                _logger.LogError(e, e.Message);
                return NotFound(e.Message);

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

    }
}