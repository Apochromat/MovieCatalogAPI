using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;
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

        public ICollection<Movie> UserFavorites { get; set; } = new List<Movie>();

        public User(UserRegisterModel userRegisterModel) {
            UserId = Guid.NewGuid();
            Name = userRegisterModel.name;
            Username = userRegisterModel.userName.ToLower();
            Password = Misc.ToHash(userRegisterModel.password);
            EmailAddress = userRegisterModel.email;
            BirthDate = userRegisterModel.birthDate;
            Gender = userRegisterModel.gender;
        }

        public void Modify(ProfileModel profileModel) {
            this.EmailAddress = profileModel.email;
            this.AvatarLink = profileModel.avatarLink;
            this.Name = profileModel.name;
            this.BirthDate = profileModel.birthDate;
            this.Gender = profileModel.gender;
        }

        public User() { }
    }
}
