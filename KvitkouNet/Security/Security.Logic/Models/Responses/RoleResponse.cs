namespace Security.Logic.Models.Responses
{
    /// <summary>
    /// Результат добавления роли
    /// </summary>
    public class RoleResponse : ActionResponse
    {
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        public Role[] Roles { get; set; }
    }
}
