using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using webNET_Hits_backend_aspnet_project_1.Models;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;
using webNET_Hits_backend_aspnet_project_1.Models.Enum;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public class UserService : IUserService {
        public ProfileModel getprofile(String Username, ApplicationDbContext db) {
            User? user = db.Users.Where(x => x.Username == Username).FirstOrDefault();
            if (user == null) throw new KeyNotFoundException("User not found");

            return new ProfileModel(user);
        }

        public async Task<int> modifyprofile(String Username, ProfileModel profileModel, ApplicationDbContext db) {
            User? user = db.Users.Where(x => x.Username == Username).FirstOrDefault();
            if (user == null) throw new KeyNotFoundException("User not found");

            user.Modify(profileModel);

            await db.SaveChangesAsync();

            return 0;
        }
    }
}
