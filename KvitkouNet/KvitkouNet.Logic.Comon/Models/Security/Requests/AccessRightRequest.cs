namespace KvitkouNet.Logic.Common.Models.Security.Requests
{
    /// <summary>
    /// Запрос на наличие права у пользователя
    /// </summary>
    public class AccessRightRequest
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string UserLogin { get; set; }

        /// <summary>
        /// Имя права доступа
        /// </summary>
        public string AccessRightName { get; set; }
    }
}
