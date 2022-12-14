using Microsoft.AspNetCore.Mvc;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public interface IAuthService {
        Task<JsonResult> register(UserRegisterModel userRegisterModel, ApplicationDbContext db);
        JsonResult login(LoginCredentials loginCredentials, ApplicationDbContext db);
        Task<IActionResult> logout(String JwtToken);
    }
}
