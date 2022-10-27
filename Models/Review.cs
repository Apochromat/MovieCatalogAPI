using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

namespace webNET_Hits_backend_aspnet_project_1.Models {
    public class Review {
        [Key]
        public Guid ReviewId { get; set; } = Guid.NewGuid();

        [Required]
        public User User { get; set; }

        [Range(0, 10, ErrorMessage = "Оценка фильма должна быть от 1 до 10")]
        public int Rating { get; set; }

        public String? ReviewText { get; set; }

        public Boolean IsAnonymous { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Review (ReviewModifyModel reviewModifyModel, User user) {
            User = user;
            Rating = reviewModifyModel.rating;
            ReviewText = reviewModifyModel.reviewText;
            IsAnonymous = reviewModifyModel.isAnonymous;
        }

        public void Modify (ReviewModifyModel reviewModifyModel) {
            Rating = reviewModifyModel.rating;
            ReviewText = reviewModifyModel.reviewText;
            IsAnonymous = reviewModifyModel.isAnonymous;
        }

        public Review() { }
    }
}
