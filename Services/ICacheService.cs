namespace webNET_Hits_backend_aspnet_project_1.Services {
    public interface ICacheService {
        Task<Boolean> IsTokenDead(string jwtToken);
        Task SetTokenDead(string jwtToken);
        Task ClearToken(string jwtToken);
    }
}
