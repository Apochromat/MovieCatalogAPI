namespace webNET_Hits_backend_aspnet_project_1.Models.DTO {
    public class MoviesListModel {
        public ICollection<MovieElementModel>? movies { get; set; } = new List<MovieElementModel>();
    }
}
