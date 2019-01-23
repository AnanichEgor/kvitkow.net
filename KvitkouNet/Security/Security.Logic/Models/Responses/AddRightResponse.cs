namespace Security.Logic.Models.Responses
{
    /// <summary>
    /// Результат добавления права доступа
    /// </summary>
    public class AddRightResponse : ActionResponse
    {
        /// <summary>
        /// Идентификатор права доступа
        /// </summary>
        public AccessRight[] AccessRights { get; set; }
    }
}
