using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public class FavoriteMoviesService : IFavoriteMoviesService {
        public async Task<IActionResult> addfavorites(string Username, Guid MovieId, ApplicationDbContext db) {
            User? user = db.Users.Where(x => x.Username == Username).Include(x => x.UserFavorites).FirstOrDefault();
            if (user == null) { throw new KeyNotFoundException("User not found"); }

            Movie? movie = db.Movies.Where(x => x.MovieId == MovieId).Include(x => x.UserFavorites).FirstOrDefault();
            if (movie == null) { throw new KeyNotFoundException("Movie not found"); }

            if (user.UserFavorites.Contains(movie)) { throw new ArgumentException("Movie already in favorites"); }

            user.UserFavorites.Add(movie);

            await db.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<IActionResult> deletefavorites(string Username, Guid MovieId, ApplicationDbContext db) {
            User? user = db.Users.Where(x => x.Username == Username).Include(x => x.UserFavorites).FirstOrDefault();
            if (user == null) { throw new KeyNotFoundException("User not found"); }

            Movie? movie = db.Movies.Where(x => x.MovieId == MovieId).Include(x => x.UserFavorites).FirstOrDefault();
            if (movie == null) { throw new KeyNotFoundException("Movie not found"); }

            if (!user.UserFavorites.Contains(movie)) { throw new ArgumentException("Movie is not in favorites"); }

            user.UserFavorites.Remove(movie);

            await db.SaveChangesAsync();
            return new OkResult();
        }

        public MoviesListModel getfavorites(string Username, ApplicationDbContext db) {
            User? user = db.Users.Where(x => x.Username == Username).Include("UserFavorites").Include("UserFavorites.Reviews").Include("UserFavorites.MovieGenres").FirstOrDefault();
            if (user == null) { throw new KeyNotFoundException("User not found"); }

            return new MoviesListModel(user.UserFavorites.Select(x => new MovieElementModel(x)).ToList());
        }
    }
}
