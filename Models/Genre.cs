using System.ComponentModel.DataAnnotations;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

namespace webNET_Hits_backend_aspnet_project_1.Models {
    public class Genre {
        [Key]
        public Guid GenreId { get; set; } = Guid.NewGuid();

        public String? Name { get; set; }

        public String? Description { get; set; }

        public List<Movie> MovieGenres { get; set; } = new List<Movie>();

        public Genre(GenreModel genreModel) {
            GenreId = Guid.NewGuid();
            Name = genreModel.name;
        }

        public Genre() { }
    }
}
