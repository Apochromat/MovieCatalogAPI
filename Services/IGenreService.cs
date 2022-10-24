using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public interface IGenreService {
        List<GenreModel> getgenres(ApplicationDbContext db);
        Task<IActionResult> creategenre(GenreModel genreModel, ApplicationDbContext db);
        Task<IActionResult> deletegenre(Guid GenreId, ApplicationDbContext db);

    }
}
