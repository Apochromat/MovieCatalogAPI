using System.ComponentModel.DataAnnotations;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;

namespace webNET_Hits_backend_aspnet_project_1.Models.DTO {
    public class UserRegisterModel {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\-_]+$")]
        [MinLength(2)]
        [MaxLength(32)]
        public String userName { get; set; }

        [Required]
        [RegularExpression(@"^[а-яА-Яa-zA-Z0-9\-_ ]+$")]
        [MinLength(4)]
        [MaxLength(64)]
        public String name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\-_!@#№$%^&?*+=(){}[\]<>~]+$")]
        [MinLength(8)]
        [MaxLength(64)]
        public String password { get; set; }

        [EmailAddress]
        [Required]
        public String email { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime birthDate { get; set; }

        [Required]
        public Gender gender { get; set; } 
    }
}
