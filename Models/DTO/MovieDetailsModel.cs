namespace webNET_Hits_backend_aspnet_project_1.Models.DTO {
    public class MovieDetailsModel {
        public Guid id { get; set; }
        public String? name { get; set; }
        public String? poster { get; set; }
        public int? year { get; set; }
        public int? time { get; set; }
        public String? country { get; set; }
        public String? description { get; set; }
        public ICollection<GenreModel>? genres { get; set; } = new List<GenreModel>();
        public ICollection<ReviewShortModel>? reviews { get; set; } = new List<ReviewShortModel>();
        public String? tagline { get; set; }
        public String? director { get; set; }
        public int? budget { get; set; }
        public int? fees { get; set; }
        public int? ageLimit { get; set; }

        public MovieDetailsModel(Movie movie) {
            id = movie.MovieId;
            name = movie.Name;
            poster = movie.PosterLink;
            year = movie.Year;
            country = movie.Country;
            time = movie.Time;
            tagline = movie.Tagline;
            director = movie.Director;
            description = movie.Description;
            budget = movie.Budget;
            fees = movie.Fees;
            ageLimit = movie.AgeLimit;
        }

        public MovieDetailsModel() { }
    }
}
