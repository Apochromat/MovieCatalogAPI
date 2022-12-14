namespace webNET_Hits_backend_aspnet_project_1.Models.DTO {
    public class UserShortModel {
        public Guid userId { get; set; }
        public String? nickName { get; set; }
        public String? avatar { get; set; }

        public UserShortModel (User user) {
            userId = user.UserId;
            nickName = user.Username;
            avatar = user.AvatarLink;
        }

        public UserShortModel() { }
    }
}
