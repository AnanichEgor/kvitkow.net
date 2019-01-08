namespace Security.Logic.Models.Responses
{
    /// <summary>
    /// Результат добавления роли
    /// </summary>
    public class AddRoleResponse : ActionResponse
    {
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        public int Id { get; set; }
    }
}
