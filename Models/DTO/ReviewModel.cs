namespace webNET_Hits_backend_aspnet_project_1.Models.DTO {
    public class ReviewModel {
        public Guid id { get; set; }
        public int rating { get; set; }
        public String? reviewText { get; set; }
        public Boolean isAnonymous { get; set; }
        public DateTime createDateTime { get; set; }
        public UserShortModel author { get; set; }
    }
}
