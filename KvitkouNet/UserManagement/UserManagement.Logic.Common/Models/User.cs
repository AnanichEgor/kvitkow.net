namespace UserManagement.Logic.Models
{
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Учетная запись пользователя
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Профиль пользователя
        /// </summary>
        public Profile Profile { get; set; }
    }
}
