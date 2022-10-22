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

namespace webNET_Hits_backend_aspnet_project_1.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class UserController : ControllerBase {
        private readonly ApplicationDbContext db;
        private readonly IUserService _userService;

        public UserController(ApplicationDbContext context, IUserService userService) {
            db = context;
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        [Route("profile")]
        public IActionResult Get() {
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }

            try {
                String username = User.Identity.Name;
                ProfileModel profileModel = _userService.getprofile(username, db);
                return Ok(profileModel);
            } catch (ArgumentNullException e) {
                return Problem(statusCode: 404, title: e.Message);
            } catch (Exception) {
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        [Authorize]
        [HttpPut]
        [Route("profile")]
        public async Task<IActionResult> PutAsync([FromBody] ProfileModel profileModel) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try {
                String username = User.Identity.Name;
                await _userService.modifyprofile(username, profileModel, db);
                return Ok();
            } catch (ArgumentNullException e) {
                return NotFound(e.Message);
            } catch (Exception) {
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }
    }
}