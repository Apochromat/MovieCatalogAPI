using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace webNET_Hits_backend_aspnet_project_1 {
    public class JwtConfigurations {

        private readonly IConfiguration _config;

        public JwtConfigurations(IConfiguration config) {
            _config = config;
            Lifetime = _config.GetValue<int>("JwtTokenLifetime"); // время жизни токена - 60 минут
    }

        public const string Issuer = "JwtIssuer"; // издатель токена
        public const string Audience = "JwtClient"; // потребитель токена
        private const string Key = "SecretHitsCriptokey";   // ключ для шифрации
        public int Lifetime;
        public static SymmetricSecurityKey GetSymmetricSecurityKey() {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
