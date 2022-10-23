using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public class CacheService : ICacheService {
        private readonly IDistributedCache _cache;

        public CacheService(IDistributedCache cache) {
            _cache = cache;
        }

        DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddHours(6))
                    .SetSlidingExpiration(TimeSpan.FromHours(3));

        public async Task<Boolean> IsTokenDead(string jwtToken) {
            var env = await _cache.GetAsync(jwtToken);
            if (env == null || String.IsNullOrEmpty(Encoding.UTF8.GetString(env))) {
                return false;
            }
            return true;
        }

        public async Task SetTokenDead(string jwtToken) {
            var dataToCache = Encoding.UTF8.GetBytes("Dead");
            await _cache.SetAsync(jwtToken, dataToCache, options);
        }

        public async Task ClearToken(string jwtToken) {
            await _cache.RemoveAsync(jwtToken);
        }
    }
}
