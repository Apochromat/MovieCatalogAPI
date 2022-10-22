using Microsoft.AspNetCore.Mvc;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;
using webNET_Hits_backend_aspnet_project_1.Services;

namespace webNET_Hits_backend_aspnet_project_1.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class AuthController : ControllerBase {
        private readonly ApplicationDbContext db;
        private readonly IAuthService _authService;

        public AuthController(ApplicationDbContext context, IAuthService authService) {
            db = context;
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel model) {
            if (!ModelState.IsValid) //Проверка полученной модели данных
            {
                return BadRequest(ModelState);
            }

            try {
                var temp = await _authService.register(model, db);
                return Ok(temp.Value);
            } catch (ArgumentException e) {
                return Problem(statusCode: 401, title: e.Message);
            } catch (Exception) {
                // TODO: Добавить логирование
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginCredentials model) {
            if (!ModelState.IsValid) //Проверка полученной модели данных
            {
                return BadRequest(ModelState);
            }

            try {
                JsonResult temp;
                temp = await _authService.login(model, db);
                return Ok(temp);
            } catch (ArgumentException e) {
                return Problem(statusCode: 409, title: e.Message);
            } catch (Exception e) {
                // TODO: Добавить логирование
                return Problem(statusCode: 500, title: "Something went wrong");
            }
        }
    }
}