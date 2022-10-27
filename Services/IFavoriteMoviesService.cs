using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public interface IFavoriteMoviesService {
        MoviesListModel getfavorites(String Username, ApplicationDbContext db);

        Task<IActionResult> addfavorites(String Username, Guid MovieId, ApplicationDbContext db);

        Task<IActionResult> deletefavorites(String Username, Guid MovieId, ApplicationDbContext db);
    }
}
