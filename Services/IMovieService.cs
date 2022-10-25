using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public interface IMovieService {
        Task<IActionResult> createmovie(MovieDetailsModel movieDetailsModel, ApplicationDbContext db);

        Task<IActionResult> deletemovie(Guid MovieId, ApplicationDbContext db);

        MoviesPagedListModel getmoviespage(int Page, ApplicationDbContext db);

        MovieDetailsModel getmoviedetails(Guid MovieId, ApplicationDbContext db);

        Task<IActionResult> addmoviegenre(Guid MovieId, Guid GenreId, ApplicationDbContext db);

        Task<IActionResult> deletemoviegenre(Guid MovieId, Guid GenreId, ApplicationDbContext db);
    }
}
