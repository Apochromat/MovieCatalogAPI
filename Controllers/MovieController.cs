using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;
using webNET_Hits_backend_aspnet_project_1.Services;

namespace webNET_Hits_backend_aspnet_project_1.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase {
        private readonly ApplicationDbContext db;
        private readonly IMovieService _movieService;
        private readonly ICacheService _cacheService;
        private readonly ILogger<MovieController> _logger;

        public MovieController(ApplicationDbContext context, IMovieService movieService, ICacheService cacheService, ILogger<MovieController> logger) {
            db = context;
            _movieService = movieService;
            _cacheService = cacheService;
            _logger = logger;
        }

        [HttpGet]
        [Route("details/{id}")]
        public ActionResult<MovieDetailsModel> GetMovieDetails(Guid id) {
            try {
                var movieDetails = _movieService.getmoviedetails(id, db);
                _logger.LogInformation($"Succesful getting movie details: {id}");

                return Ok(movieDetails);

            } catch (KeyNotFoundException e) {
                // Catch if movie was not found in database
                _logger.LogError(e, e.Message);
                return NotFound(e.Message);

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        [HttpGet]
        [Route("{page}")]
        public ActionResult<MoviesPagedListModel> GetMoviesPage(int page = 1) {
            try {
                var moviesPagedListModel = _movieService.getmoviespage(page, db);
                _logger.LogInformation($"Succesful getting movie page: {page}");

                return Ok(moviesPagedListModel);

            } catch (ArgumentException e) {
                // Catch if page <= 0
                _logger.LogError(e, e.Message);
                return Problem(e.Message);

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("add")]
        public async Task<ActionResult> AddMovie([FromBody]MovieDetailsModel movieDetailsModel) {
            try {
                // Logout checking
                if (await _cacheService.IsTokenDead(Request.Headers["Authorization"])) return Unauthorized("Token is expired");

                await _movieService.createmovie(movieDetailsModel, db);
                _logger.LogInformation($"Succesful movie creation: {movieDetailsModel.name}");
                return Ok();

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("delete/{id}")]
        public async Task<ActionResult> RemoveMovie(Guid id) {
            try {
                // Logout checking
                if (await _cacheService.IsTokenDead(Request.Headers["Authorization"])) return Unauthorized("Token is expired");

                await _movieService.deletemovie(id, db);
                _logger.LogInformation($"Succesful movie removing: {id}");
                return Ok();

            } catch (KeyNotFoundException e) {
                // Catch if movie was not found in database
                _logger.LogError(e, e.Message);
                return NotFound(e.Message);

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("{movieid}/genres/{genreid}/add")]
        public async Task<ActionResult> AddMovieGenre(Guid movieid, Guid genreid) {
            try {
                // Logout checking
                if (await _cacheService.IsTokenDead(Request.Headers["Authorization"])) return Unauthorized("Token is expired");

                await _movieService.addmoviegenre(movieid, genreid, db);
                _logger.LogInformation($"Succesful adding genre {genreid} for movie {movieid}");

                return Ok();

            } catch (ArgumentException e) {
                // Catch if movie already contain genre
                _logger.LogError(e, e.Message);
                return Conflict(e.Message);

            } catch (KeyNotFoundException e) {
                // Catch if movie or genre was not found in database
                _logger.LogError(e, e.Message);
                return NotFound(e.Message);

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("{movieid}/genres/{genreid}/delete")]
        public async Task<ActionResult> RemoveMovieGenre(Guid movieid, Guid genreid) {
            try {
                // Logout checking
                if (await _cacheService.IsTokenDead(Request.Headers["Authorization"])) return Unauthorized("Token is expired");

                await _movieService.deletemoviegenre(movieid, genreid, db);
                _logger.LogInformation($"Succesful removing genre {genreid} for movie {movieid}");

                return Ok();

            } catch (ArgumentException e) {
                // Catch if movie does not contain genre
                _logger.LogError(e, e.Message);
                return Conflict(e.Message);

            } catch (KeyNotFoundException e) {
                // Catch if movie or genre was not found in database
                _logger.LogError(e, e.Message);
                return NotFound(e.Message);

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }
    }
}