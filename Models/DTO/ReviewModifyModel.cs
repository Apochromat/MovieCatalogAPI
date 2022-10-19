using System.ComponentModel.DataAnnotations;

namespace webNET_Hits_backend_aspnet_project_1.Models.DTO {
    public class ReviewModifyModel {
        [Required]
        public String reviewText { get; set;}

        [Range(0, 10, ErrorMessage = "Значение рейтинга должно быть в промежутке от 0 до 10")]
        public int rating { get; set;}

        public Boolean isAnonymous { get; set;}
    }
}
