using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        [Authorize]
        [Route("{movieId}/review/add")]
        public async Task<ActionResult> AddReview(Guid movieId, [FromBody] ReviewModifyModel reviewModifyModel) {
            try {
                // Logout checking
                if (await _cacheService.IsTokenDead(Request.Headers["Authorization"])) return Unauthorized("Token is expired");

                await _reviewService.addreview(User.Identity.Name, movieId, reviewModifyModel, db);
                _logger.LogInformation($"Succesful adding review from {User.Identity.Name} for movie {movieId}");

                return Ok();

            } catch (ArgumentException e) {
                // Catch if review already exists
                _logger.LogError(e, e.Message);
                return Conflict(e.Message);

            } catch (KeyNotFoundException e) {
                // Catch if user or movie does not exist
                _logger.LogError(e, e.Message);
                return NotFound(e.Message);

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        [HttpPut]
        [Authorize]
        [Route("{movieId}/review/{reviewId}/edit")]
        public async Task<ActionResult> EditReview(Guid movieId, Guid reviewId, [FromBody] ReviewModifyModel reviewModifyModel) {
            try {
                // Logout checking
                if (await _cacheService.IsTokenDead(Request.Headers["Authorization"])) return Unauthorized("Token is expired");

                await _reviewService.editreview(User.Identity.Name, reviewId, reviewModifyModel, db);
                _logger.LogInformation($"Succesful editing review {reviewId} from {User.Identity.Name} for movie {movieId}");

                return Ok();

            } catch (NotSupportedException e) {
                // Catch if user is not review author
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 405, title: e.Message);

            } catch (KeyNotFoundException e) {
                // Catch if review does not exist
                _logger.LogError(e, e.Message);
                return NotFound(e.Message);

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("{movieId}/review/{reviewId}/delete")]
        public async Task<ActionResult> DeleteReview(Guid movieId, Guid reviewId) {
            try {
                // Logout checking
                if (await _cacheService.IsTokenDead(Request.Headers["Authorization"])) return Unauthorized("Token is expired");

                await _reviewService.deletereview(User.Identity.Name, reviewId, db);
                _logger.LogInformation($"Succesful deleting review {reviewId} from {User.Identity.Name} for movie {movieId}");
                return Ok();

            } catch (NotSupportedException e) {
                // Catch if user is not review author
                _logger.LogError(e, e.Message);
                return Problem(statusCode:405, title: e.Message);

            } catch (KeyNotFoundException e) {
                // Catch if review does not exist
                _logger.LogError(e, e.Message);
                return NotFound(e.Message);

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

    }
}