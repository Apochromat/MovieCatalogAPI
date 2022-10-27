using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;
using webNET_Hits_backend_aspnet_project_1.Services;
using System.Security.Principal;
using System.Diagnostics;

namespace webNET_Hits_backend_aspnet_project_1.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class UserController : ControllerBase {
        private readonly ApplicationDbContext db;
        private readonly IUserService _userService;
        private readonly ICacheService _cacheService;
        private readonly ILogger<UserController> _logger;

        public UserController(ApplicationDbContext context, IUserService userService, ICacheService cacheService, ILogger<UserController> logger) {
            db = context;
            _userService = userService;
            _cacheService = cacheService;
            _logger = logger;
        }  

        [Authorize]
        [HttpGet]
        [Route("profile")]
        public async Task<ActionResult<ProfileModel>> GetAsync() {
            try {
                // Logout checking
                if (await _cacheService.IsTokenDead(Request.Headers["Authorization"])) return Unauthorized("Token is expired");

                ProfileModel profileModel = _userService.getprofile(User.Identity.Name, db);

                return Ok(profileModel);

            } catch (KeyNotFoundException e) {
                // Catch if "username" was not found in database
                _logger.LogError(e, e.Message);
                return NotFound(e.Message);

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        [Authorize]
        [HttpPut]
        [Route("profile")]
        public async Task<IActionResult> PutAsync([FromBody] ProfileModel profileModel) {
            if (!ModelState.IsValid) { // Model checking
                return BadRequest(ModelState);
            }
            try {
                // Logout checking
                if (await _cacheService.IsTokenDead(Request.Headers["Authorization"])) return Unauthorized("Token is expired");

                await _userService.modifyprofile(User.Identity.Name, profileModel, db);

                return Ok("Success");

            } catch (KeyNotFoundException e) {
                // Catch if "username" was not found in database
                _logger.LogError(e, e.Message);
                return NotFound(e.Message);

            } catch (Exception e) {
                _logger.LogError(e, e.Message);
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }
    }
}