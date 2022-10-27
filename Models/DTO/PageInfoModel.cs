namespace webNET_Hits_backend_aspnet_project_1.Models.DTO {
    public class PageInfoModel {
        public int pageSize { get; set; } 
        public int pageCount { get; set; } 
        public int currentPage { get; set; } 

        public PageInfoModel(int pageSize, int pageCount, int currentPage) {
            this.pageSize = pageSize;
            this.pageCount = pageCount;
            this.currentPage = currentPage;
        }

        public PageInfoModel() { }
    }
}
