using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;

namespace webNET_Hits_backend_aspnet_project_1.Models
{
    public class User {
        public Guid UserId { get; set; } = Guid.NewGuid();

        public String? Username { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Некорректный email-адрес")]
        public String EmailAddress { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public String Password { get; set; }

        public String? AvatarLink { get; set; }

        public String Role { get; set; } = "user";

        public Gender Gender { get; set; }

        public List<Movie> UserFavorites { get; set; } = new List<Movie>();
    }
}
