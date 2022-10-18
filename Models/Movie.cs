using System.ComponentModel.DataAnnotations;

namespace webNET_Hits_backend_aspnet_project_1.Models {
    public class Movie {
        [Key]
        public Guid MovieId { get; set; } = Guid.NewGuid();

        public String? Name { get; set; }

        public String? PosterLink { get; set; }

        public int Year { get; set; }

        public String? Country { get; set; }

        public int Time { get; set; }

        public String? Tagline { get; set; }

        public String? Director { get; set; }

        public int? Budget { get; set; }

        public int? Fees { get; set; }

        public int? AgeLimit { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<User> UserFavorites { get; set; }
        public ICollection<Genre> MovieGenres { get; set; }


    }
}
