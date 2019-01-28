namespace KvitkouNet.Logic.Common.Models.Security.Requests
{
    /// <summary>
    /// Запрос на регистрацию пользователя
    /// </summary>
    public class RegistrationRequest
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string UserLogin { get; set; }

        /// <summary>
        /// Зашифрованный пароль
        /// </summary>
        public string PasswordWithSalt { get; set; }

        /// <summary>
        /// Электронный ящик
        /// </summary>
        public string Email { get; set; }
    }
}
