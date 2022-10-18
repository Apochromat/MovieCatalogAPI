using System.ComponentModel.DataAnnotations;

namespace webNET_Hits_backend_aspnet_project_1.Models {
    public class Genre {
        [Key]
        public Guid GenreId { get; set; } = Guid.NewGuid();

        public String? Name { get; set; }

        public String? Description { get; set; }
        public ICollection<Movie> MovieGenres { get; set; }
    }
}
