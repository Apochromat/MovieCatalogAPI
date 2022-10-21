using System.ComponentModel.DataAnnotations;

namespace webNET_Hits_backend_aspnet_project_1.Models {
    public class Movie {
        [Key]
        public Guid MovieId { get; set; } = Guid.NewGuid();

        public String Name { get; set; }

        public String? PosterLink { get; set; }

        public int? Year { get; set; }

        public String? Country { get; set; }

        public int? Time { get; set; }

        public String? Tagline { get; set; }

        public String? Director { get; set; }

        public String? Description { get; set; }

        public int? Budget { get; set; }

        public int? Fees { get; set; }

        public int? AgeLimit { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<User> UserFavorites { get; set; } = new List<User>();
        public ICollection<Genre> MovieGenres { get; set; } = new List<Genre>();


    }
}
