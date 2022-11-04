using System.ComponentModel.DataAnnotations;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;

namespace webNET_Hits_backend_aspnet_project_1.Models.DTO {
    public class ProfileModel {
        [Required]
        public Guid id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\-_]+$")]
        [MinLength(2)]
        [MaxLength(32)]
        public String nickName { get; set; }

        [Required]
        [EmailAddress]
        public String email { get; set; }

        [Url]
        public String? avatarLink { get; set; }

        [Required]
        [RegularExpression(@"^[а-яА-Яa-zA-Z0-9\-_ ]+$")]
        [MinLength(4)]
        [MaxLength(64)]
        public String name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime birthDate { get; set; }

        [Required]
        public Gender gender { get; set; }

        public ProfileModel (User user) {
            this.id = user.UserId;
            this.nickName = user.Username;
            this.email = user.EmailAddress;
            this.avatarLink = user.AvatarLink;
            this.name = user.Name;
            this.birthDate = user.BirthDate;
            this.gender = user.Gender;
        }

        public ProfileModel() { }
    }
}
