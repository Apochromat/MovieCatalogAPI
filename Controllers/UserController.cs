using Microsoft.AspNetCore.Mvc;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;


namespace webNET_Hits_backend_aspnet_project_1.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class UserController : ControllerBase {
        private readonly ApplicationDbContext db;

        public UserController(ApplicationDbContext context) {
            db = context;
        }
    }
}