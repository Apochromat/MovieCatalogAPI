using System.ComponentModel.DataAnnotations;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;

namespace webNET_Hits_backend_aspnet_project_1.Models.DTO {
    public class UserRegisterModel {
        [Required]
        public String userName { get; set; }

        [Required]
        public String name { get; set; }

        [Required]
        public String password { get; set; }

        [EmailAddress(ErrorMessage = "Некорректный email-адрес")]
        [Required]
        public String email { get; set; }

        public DateTime birthDate { get; set; }

        public Gender gender { get; set; } 
    }
}
