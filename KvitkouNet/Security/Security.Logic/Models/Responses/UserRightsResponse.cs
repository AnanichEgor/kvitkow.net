namespace Security.Logic.Models.Responses
{
    /// <summary>
    /// Результат добавления фичи
    /// </summary>
    public class UserRightsResponse : ActionResponse
    {
        /// <summary>
        /// Идентификатор фичи
        /// </summary>
        public UserRights UserRights { get; set; }
    }
}
