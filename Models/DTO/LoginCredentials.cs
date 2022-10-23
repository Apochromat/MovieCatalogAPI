using System.ComponentModel.DataAnnotations;

namespace webNET_Hits_backend_aspnet_project_1.Models.DTO {
    public class LoginCredentials {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\-_]+$")]
        [MinLength(2)]
        [MaxLength(32)]
        public String username { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\-_!@#№$%^&?*+=(){}[\]<>~]+$")]
        [MinLength(8)]
        [MaxLength(64)]
        public String password { get; set; }
    }
}
