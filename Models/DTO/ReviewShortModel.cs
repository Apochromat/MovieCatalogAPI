namespace webNET_Hits_backend_aspnet_project_1.Models.DTO {
    public class ReviewShortModel {
        public Guid id { get; set; }
        public int rating { get; set; }

    public ReviewShortModel(Review review) {
            id = review.ReviewId;
            rating = review.Rating;
        }
    }
}
