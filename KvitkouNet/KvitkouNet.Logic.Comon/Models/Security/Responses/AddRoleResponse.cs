namespace KvitkouNet.Logic.Common.Models.Security.Responses
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
