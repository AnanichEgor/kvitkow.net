using Chat.Data.DbModels.Abstraction;

namespace Chat.Data.DbModels
{
    public class UserDb : SystemDataForAllModelsDb<string>
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Роль пользователя.
        /// </summary>
        public string UserRole { get; set; }

        /// <summary>
        /// Avatar пользователя в Chat.
        /// </summary>
        public string Avatar { get; set; }

        public string SettingsId { get; set; }
        public SettingsDb Settings { get; set; }

        public string RoomId { get; set; }
        public RoomDb Room { get; set; }
    }
}
