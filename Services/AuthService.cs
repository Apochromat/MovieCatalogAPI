using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using webNET_Hits_backend_aspnet_project_1.Controllers;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public class AuthService : IAuthService {
        private readonly ICacheService _cacheService;

        public AuthService(ICacheService cacheService) {
            _cacheService = cacheService;
        }

        public async Task<JsonResult> register(UserRegisterModel userRegisterModel, ApplicationDbContext db) {
            foreach (User n_user in db.Users) {
                if (n_user.Username == userRegisterModel.userName.ToLower())
                    throw new ArgumentException("User already exists");
            }
            User user = new User {
                Name = userRegisterModel.name,
                Username = userRegisterModel.userName.ToLower(),
                Password = userRegisterModel.password,
                EmailAddress = userRegisterModel.email,
                BirthDate = userRegisterModel.birthDate,
                Gender = userRegisterModel.gender
            };
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return await login(new LoginCredentials { username = userRegisterModel.userName, password = userRegisterModel.password }, db);
        }

        public async Task<JsonResult> login(LoginCredentials loginCredentials, ApplicationDbContext db) {
            var identity = await GetIdentity(loginCredentials.username.ToLower(), loginCredentials.password, db);
            if (identity == null) {
                throw new ArgumentException("Incorrect username or password");
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: JwtConfigurations.Issuer,
                audience: JwtConfigurations.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromHours(JwtConfigurations.Lifetime)),
                signingCredentials: new SigningCredentials(JwtConfigurations.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new {
                access_token = encodedJwt,
                username = identity.Name
            };

            return new JsonResult(response);
        }

        public async Task<IActionResult> logout(String JwtToken) {
            await _cacheService.SetTokenDead(JwtToken);
            return new OkResult();
        }

        private async Task<ClaimsIdentity?> GetIdentity(string username, string password, ApplicationDbContext db) {
            var user = db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (user == null) {
                return null;
            }

            var claims = new List<Claim>{
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
}
}
