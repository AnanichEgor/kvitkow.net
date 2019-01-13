namespace Chat.Logic.Models
{
    public class User
    {
        /// <summary>
        /// UserId пользователя из UserManagement.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Роль пользователя.
        /// </summary>
        public string UserRole { get; set; }

        /// <summary>
        /// Avatar пользователя в чате (Url к картинке на диске).
        /// </summary>
        public string Avatar { get; set; }
    }
}
