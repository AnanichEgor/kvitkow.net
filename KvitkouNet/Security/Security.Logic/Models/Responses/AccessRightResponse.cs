namespace Security.Logic.Models.Responses
{
    /// <summary>
    /// Результат изменения прав доступа
    /// </summary>
    public class AccessRightResponse : ActionResponse
    {
        /// <summary>
        /// Идентификатор права доступа
        /// </summary>
        public AccessRight[] AccessRights { get; set; }
    }
}
