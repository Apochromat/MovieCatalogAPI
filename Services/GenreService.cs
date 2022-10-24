using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public class GenreService : IGenreService {
        
        public async Task<IActionResult> creategenre(GenreModel genreModel, ApplicationDbContext db) {
            Genre genre = new Genre(genreModel);

            await db.Genres.AddAsync(genre);
            await db.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<IActionResult> deletegenre(Guid GenreId, ApplicationDbContext db) {
            Genre? genre = null;
            foreach (Genre n_genre in db.Genres) {
                if (n_genre.GenreId == GenreId) {
                    genre = n_genre;
                }
            }
            if (genre == null) {
                throw new ArgumentNullException("Genre not found");
            }

            db.Genres.Remove(genre);
            await db.SaveChangesAsync();
            return new OkResult();
        }

        public List<GenreModel> getgenres(ApplicationDbContext db) {
            var genres = db.Genres.AsEnumerable();
            List<GenreModel> genreModels = genres.Select(x => new GenreModel(x)).ToList();

            return genreModels;
        }

    }
}
