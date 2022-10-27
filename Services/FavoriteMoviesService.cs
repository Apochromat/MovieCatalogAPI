using Microsoft.AspNetCore.Mvc;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public class FavoriteMoviesService : IFavoriteMoviesService {
        public Task<IActionResult> addfavorites(string Username, Guid MovieId, ApplicationDbContext db) {
            throw new NotImplementedException();
        }

        public Task<IActionResult> deletefavorites(string Username, Guid MovieId, ApplicationDbContext db) {
            throw new NotImplementedException();
        }

        public MoviesListModel getfavorites(string Username, ApplicationDbContext db) {
            throw new NotImplementedException();
        }
    }
}
