using Microsoft.AspNetCore.Mvc;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;
using webNET_Hits_backend_aspnet_project_1.Services;

namespace webNET_Hits_backend_aspnet_project_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase {
        private readonly ApplicationDbContext db;
        private readonly IUserService _userService;

        public AuthController(ApplicationDbContext context, IUserService authService) {
            db = context;
            _userService = authService;
        }
    }
}