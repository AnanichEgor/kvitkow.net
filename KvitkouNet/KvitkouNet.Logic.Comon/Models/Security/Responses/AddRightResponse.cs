namespace KvitkouNet.Logic.Common.Models.Security.Responses
{
    /// <summary>
    /// Результат добавления права доступа
    /// </summary>
    public class AddRightResponse : ActionResponse
    {
        /// <summary>
        /// Идентификатор права доступа
        /// </summary>
        public int Id { get; set; }
    }
}
