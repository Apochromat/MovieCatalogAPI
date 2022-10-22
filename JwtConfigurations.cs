using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace webNET_Hits_backend_aspnet_project_1 {
    public class JwtConfigurations {
        public const string Issuer = "JwtIssuer"; // издатель токена
        public const string Audience = "JwtClient"; // потребитель токена
        private const string Key = "SecretHitsCriptokey";   // ключ для шифрации
        public const int Lifetime = 60; // время жизни токена - 60 минут
        public static SymmetricSecurityKey GetSymmetricSecurityKey() {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
