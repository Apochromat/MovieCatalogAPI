using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public class MovieService : IMovieService {
        public async Task<IActionResult> createmovie(MovieDetailsModel movieDetailsModel, ApplicationDbContext db) {
            Movie movie = new Movie(movieDetailsModel);

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

            MovieDetailsModel movieDetailsModel = new MovieDetailsModel(movie);

            return movieDetailsModel;
        }

        public async Task<MoviesPagedListModel> getmoviespage(int Page, ApplicationDbContext db) {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> addmoviegenre(Guid MovieId, Guid GenreId, ApplicationDbContext db) {
            Movie? movie = null;
            foreach (Movie n_movie in db.Movies) {
                if (n_movie.MovieId == MovieId) {
                    movie = n_movie;
                }
            }
            if (movie == null) {
                throw new ArgumentNullException("Movie not found");
            }

            Genre? genre = null;
            foreach (Genre n_genre in db.Genres) {
                if (n_genre.GenreId == GenreId) {
                    genre = n_genre;
                }
            }
            if (genre == null) {
                throw new ArgumentNullException("Genre not found");
            }

            movie.MovieGenres.Add(genre);
            //genre.MovieGenres.Add(movie);

            await db.SaveChangesAsync();

            return new OkObjectResult(movie.MovieGenres);
        }

        public async Task<IActionResult> deletemoviegenre(Guid MovieId, Guid GenreId, ApplicationDbContext db) {
            Movie? movie = null;
            foreach (Movie n_movie in db.Movies) {
                if (n_movie.MovieId == MovieId) {
                    movie = n_movie;
                }
            }
            if (movie == null) {
                throw new ArgumentNullException("Movie not found");
            }

            Genre? genre = null;
            foreach (Genre n_genre in db.Genres) {
                if (n_genre.GenreId == GenreId) {
                    genre = n_genre;
                }
            }
            if (genre == null) {
                throw new ArgumentNullException("Genre not found");
            }

            var var1 = movie.MovieGenres.ToList();
            //var var2 = genre.MovieGenres.ToList();

            //movie.MovieGenres.Remove(genre);
            //genre.MovieGenres.Remove(movie);

            await db.SaveChangesAsync();

            return new OkObjectResult(movie.MovieGenres);
        }
    }
}
