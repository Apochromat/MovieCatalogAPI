using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public class MovieService : IMovieService {
        public async Task<IActionResult> createmovie(MovieDetailsModel movieDetailsModel, ApplicationDbContext db) {
            Movie movie = new Movie {
                Name = movieDetailsModel.name,
                PosterLink = movieDetailsModel.poster,
                Year = movieDetailsModel.year,
                Country = movieDetailsModel.country,
                Time = movieDetailsModel.time,
                Tagline = movieDetailsModel.tagline,
                Director = movieDetailsModel.director,
                Description = movieDetailsModel.description,
                Budget = movieDetailsModel.budget,
                Fees = movieDetailsModel.fees,
                AgeLimit = movieDetailsModel.ageLimit
            };

            await db.Movies.AddAsync(movie);
            await db.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<IActionResult> deletemovie(Guid MovieId, ApplicationDbContext db) {
            Movie? movie = null;
            foreach (Movie n_movie in db.Movies) {
                if (n_movie.MovieId == MovieId) {
                    movie = n_movie;
                }
            }
            if (movie == null) {
                throw new ArgumentNullException("Movie not found");
            }

            db.Movies.Remove(movie);
            await db.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<MovieDetailsModel> getmoviedetails(Guid MovieId, ApplicationDbContext db) {
            Movie? movie = null;
            foreach (Movie n_movie in db.Movies) {
                if (n_movie.MovieId == MovieId) {
                    movie = n_movie;
                }
            }
            if (movie == null) {
                throw new ArgumentNullException("Movie not found");
            }

            MovieDetailsModel movieDetailsModel = new MovieDetailsModel {
                id = movie.MovieId,
                name = movie.Name,
                poster = movie.PosterLink,
                year = movie.Year,
                country = movie.Country,
                time = movie.Time,
                tagline = movie.Tagline,
                director = movie.Director,
                description = movie.Description,
                budget = movie.Budget,
                fees = movie.Fees,
                ageLimit = movie.AgeLimit
            };

            return movieDetailsModel;
        }

        public async Task<MoviesPagedListModel> getmoviespage(int Page, ApplicationDbContext db) {
            throw new NotImplementedException();
        }

        Task<IActionResult> IMovieService.creategenre(GenreModel genreModel, ApplicationDbContext db) {
            throw new NotImplementedException();
        }

        Task<IActionResult> IMovieService.deletegenre(Guid GenreId, ApplicationDbContext db) {
            throw new NotImplementedException();
        }

        Task<List<GenreModel>> IMovieService.getgenres() {
            throw new NotImplementedException();
        }
    }
}
