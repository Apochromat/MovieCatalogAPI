namespace webNET_Hits_backend_aspnet_project_1.Models.DTO {
    public class GenreModel {
        public Guid id { get; set; }
        public String? name { get; set; }

        public GenreModel(Genre genre) {
            id = genre.GenreId;
            name = genre.Name;
        }

        public GenreModel() { }
    }
}
