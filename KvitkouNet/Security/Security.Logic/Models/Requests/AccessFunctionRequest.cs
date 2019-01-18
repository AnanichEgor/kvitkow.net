namespace Security.Logic.Models.Requests
{
    /// <summary>
    /// Запрос на наличие прав на функцию у пользователя
    /// </summary>
    public class AccessFunctionRequest
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string UserLogin { get; set; }

        /// <summary>
        /// Имя функции
        /// </summary>
        public string AccessFunctionName { get; set; }
    }
}
