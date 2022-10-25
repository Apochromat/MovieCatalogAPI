namespace webNET_Hits_backend_aspnet_project_1.Models.DTO {
    public class MoviesPagedListModel {
        public ICollection<MovieElementModel> movies { get; set; }
        public PageInfoModel pageInfo { get; set; }

        public MoviesPagedListModel(ICollection<MovieElementModel> movies, PageInfoModel pageInfo) {
            this.movies = movies;
            this.pageInfo = pageInfo;
        }

        public MoviesPagedListModel(ICollection<MovieElementModel> movies, int pageSize, int pageCount, int currentPage) {
            this.movies = movies;
            this.pageInfo = new PageInfoModel(pageSize, pageCount, currentPage);
        }
    }
}
