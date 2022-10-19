using System.ComponentModel.DataAnnotations;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;

namespace webNET_Hits_backend_aspnet_project_1.Models.DTO {
    public class ProfileModel {
        public Guid id { get; set; }

        public String? nickName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Некорректный email-адрес")]
        public String email { get; set; }

        public String? avatarLink { get; set; }

        [Required]
        public String name { get; set; }

        [Required]
        public DateTime birthDate { get; set; }

        public Gender gender { get; set; }
    }
}
