using System.ComponentModel.DataAnnotations;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

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

        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<User> UserFavorites { get; set; } = new List<User>();
        public List<Genre> MovieGenres { get; set; } = new List<Genre>();

        public Movie(MovieDetailsModel movieDetailsModel) {
            Name = movieDetailsModel.name;
            PosterLink = movieDetailsModel.poster;
            Year = movieDetailsModel.year;
            Country = movieDetailsModel.country;
            Time = movieDetailsModel.time;
            Tagline = movieDetailsModel.tagline;
            Director = movieDetailsModel.director;
            Description = movieDetailsModel.description;
            Budget = movieDetailsModel.budget;
            Fees = movieDetailsModel.fees;
            AgeLimit = movieDetailsModel.ageLimit;
        }

        public Movie() { }
    }
}
