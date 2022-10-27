using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public class MovieService : IMovieService {
        private readonly IReviewService _reviewService;
        public MovieService(IReviewService reviewService) {
            _reviewService = reviewService;
        }
        public async Task<IActionResult> createmovie(MovieDetailsModel movieDetailsModel, ApplicationDbContext db ) {
            Movie movie = new Movie(movieDetailsModel);

            await db.Movies.AddAsync(movie);
            await db.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<IActionResult> deletemovie(Guid MovieId, ApplicationDbContext db) {
            Movie? movie = db.Movies.Where(x => x.MovieId == MovieId).Include(x => x.MovieGenres).FirstOrDefault();
            if (movie == null) {
                throw new ArgumentNullException("Movie not found");
            }

            db.Movies.Remove(movie);
            await db.SaveChangesAsync();
            return new OkResult();
        }

        public MovieDetailsModel getmoviedetails(Guid MovieId, ApplicationDbContext db) {
            Movie? movie = db.Movies.Where(x => x.MovieId == MovieId).Include(x => x.MovieGenres).Include(x => x.Reviews).ThenInclude(x => x.User).FirstOrDefault();
            if (movie == null) {
                throw new ArgumentNullException("Movie not found");
            }

            MovieDetailsModel movieDetailsModel = new MovieDetailsModel(movie, _reviewService.getreviewmodels(MovieId, db));

            return movieDetailsModel;
        }

        public MoviesPagedListModel getmoviespage(int Page, ApplicationDbContext db) {
            const int pageSize = 2;
            if (Page <= 0) { throw new ArgumentException("Page must be higher then zero"); }

            List<Movie> movies = db.Movies.Include(x => x.MovieGenres).Include(x => x.Reviews).ToList();
            List<List<Movie>> splittedMovies = Misc.Split<Movie>(movies, pageSize);
            List<MovieElementModel> moviesList = new List<MovieElementModel>();

            int pageCount = splittedMovies.Count;
            if (Page <= pageCount) {
                moviesList = splittedMovies[Page - 1].Select(x => new MovieElementModel(x)).ToList();
            }

            return new MoviesPagedListModel(moviesList, pageSize, pageCount, Page);
        }

        public async Task<IActionResult> addmoviegenre(Guid MovieId, Guid GenreId, ApplicationDbContext db) {
            Movie? movie = db.Movies.Where(x => x.MovieId == MovieId).Include(x => x.MovieGenres).FirstOrDefault();
            if (movie == null) {
                throw new ArgumentNullException("Movie not found");
            }

            Genre? genre = db.Genres.Where(x => x.GenreId == GenreId).Include(x => x.MovieGenres).FirstOrDefault();
            if (genre == null) {
                throw new ArgumentNullException("Genre not found");
            }

            movie.MovieGenres.Add(genre);

            await db.SaveChangesAsync();

            return new OkObjectResult(db.Movies.Where(x => x.MovieId == MovieId));
        }

        public async Task<IActionResult> deletemoviegenre(Guid MovieId, Guid GenreId, ApplicationDbContext db) {
            Movie? movie = db.Movies.Where(x => x.MovieId == MovieId).Include(x => x.MovieGenres).FirstOrDefault();
            if (movie == null) {
                throw new ArgumentNullException("Movie not found");
            }

            Genre? genre = db.Genres.Where(x => x.GenreId == GenreId).Include(x => x.MovieGenres).FirstOrDefault();
            if (genre == null) {
                throw new ArgumentNullException("Genre not found");
            }

            movie.MovieGenres.Remove(genre);
            db.SaveChanges();

            await db.SaveChangesAsync();

            return new OkObjectResult(db.Movies.Where(x => x.MovieId == MovieId));
        }
    }
}
