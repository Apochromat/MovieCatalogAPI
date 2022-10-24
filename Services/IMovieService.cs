using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public interface IMovieService {
        Task<IActionResult> createmovie(MovieDetailsModel movieDetailsModel, ApplicationDbContext db);

        Task<IActionResult> deletemovie(Guid MovieId, ApplicationDbContext db);

        Task<MoviesPagedListModel> getmoviespage(int Page, ApplicationDbContext db);

        Task<MovieDetailsModel> getmoviedetails(Guid MovieId, ApplicationDbContext db);

        Task<List<GenreModel>> getgenres();
        Task<IActionResult> creategenre(GenreModel genreModel, ApplicationDbContext db);
        Task<IActionResult> deletegenre(Guid GenreId, ApplicationDbContext db);

    }
}
