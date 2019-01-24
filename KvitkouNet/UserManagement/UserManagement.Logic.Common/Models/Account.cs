
namespace UserManagement.Logic.Models
{
    public class Account
    {
        /// <summary>
        /// Уникальный идентификатор учетной записи
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Электронный адрес пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }
    }
}
