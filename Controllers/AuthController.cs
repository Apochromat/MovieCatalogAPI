using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;
using webNET_Hits_backend_aspnet_project_1.Services;

namespace webNET_Hits_backend_aspnet_project_1.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AuthController : ControllerBase {
        private readonly ApplicationDbContext db;
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ApplicationDbContext context, IAuthService authService, ILogger<AuthController> logger) {
            db = context;
            _authService = authService;
            _logger = logger;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel model) {
            if (!ModelState.IsValid) { // Model checking
                return BadRequest(ModelState);
            }

            try {
                JsonResult token = await _authService.register(model, db);
                _logger.LogInformation($"Successful register: {model.userName}");
                return Ok(token.Value);

            } catch (ArgumentException e) {
                // Catch if user with this usename already exists
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 401, title: e.Message);

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginCredentials model) {
            if (!ModelState.IsValid) { // Model checking
                return BadRequest(ModelState);
            }

            try {
                JsonResult token = await _authService.login(model, db);
                _logger.LogInformation($"Successful login: {model.username}");
                return Ok(token.Value);

            } catch (ArgumentException e) {
                // Catch incorrect username or password
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 409, title: e.Message);

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        [Authorize]
        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout() {
            try {
                var head = Request.Headers["Authorization"];
                await _authService.logout(head);
                _logger.LogInformation($"Successful logout: {User.Identity.Name}");
                return Ok($"Token set invalid: {head}");

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        //[HttpGet]
        //[Authorize(Roles = "admin")]
        //[Route("test_admin")]
        //public async Task<IActionResult> TestAdmin() {
        //    try {
        //        if (await _cacheService.IsTokenDead(Request.Headers["Authorization"])) return Unauthorized("Token is expired");
        //        return Ok($"Ваш админский логин: {User.Identity.Name}");
        //    } catch (Exception) {
        //        return Problem(statusCode: 500, title: "Something went wrong");
        //    }
        //}

        //[HttpGet]
        //[Authorize]
        //[Route("test")]
        //public async Task<IActionResult> TestAsync() {
        //    try {
        //        if (await _cacheService.IsTokenDead(Request.Headers["Authorization"])) return Unauthorized("Token is expired");
        //        return Ok($"Ваш логин: {User.Identity.Name}");
        //    } catch (Exception) {
        //        return Problem(statusCode: 500, title: "Something went wrong");
        //    }
        //}
    }
}