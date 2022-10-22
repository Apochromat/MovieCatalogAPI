using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using webNET_Hits_backend_aspnet_project_1.Models.DTO;

namespace webNET_Hits_backend_aspnet_project_1.Services {
    public interface IUserService {
        ProfileModel getprofile(String Username, ApplicationDbContext db);

        Task<int> modifyprofile(String Username, ProfileModel profileModel, ApplicationDbContext db);
    }
}
