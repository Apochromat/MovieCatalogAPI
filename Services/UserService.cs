using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public class UserService : IUserService {
        public ProfileModel getprofile(String Username, ApplicationDbContext db) {
            User? user = null;
            foreach (User n_user in db.Users) {
                if (n_user.Username == Username) user = n_user;
            }
            if (user == null) throw new ArgumentNullException("User not found");

            return new ProfileModel {
                id = user.UserId,
                nickName = user.Username,
                email = user.EmailAddress,
                avatarLink = user.AvatarLink,
                name = user.Name,
                birthDate = user.BirthDate,
                gender = user.Gender
            };
        }

        public async Task<int> modifyprofile(String Username, ProfileModel profileModel, ApplicationDbContext db) {
            User? user = null;
            foreach (User n_user in db.Users) {
                if (n_user.Username == Username) user = n_user;
            }
            if (user == null) throw new ArgumentNullException("User not found");

            user.UserId = profileModel.id;
            user.Username = profileModel.nickName.ToLower();
            user.EmailAddress = profileModel.email;
            user.AvatarLink = profileModel.avatarLink;
            user.Name = profileModel.name;
            user.BirthDate = profileModel.birthDate;
            user.Gender = profileModel.gender;

            await db.SaveChangesAsync();

            return 0;
        }
    }
}
