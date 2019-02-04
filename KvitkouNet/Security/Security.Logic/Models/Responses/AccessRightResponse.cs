namespace Security.Logic.Models.Responses
{
    public class AccessRightResponse : ActionResponse
    {
        /// <summary>
        /// Права доступа
        /// </summary>
        public AccessRight[] AccessRights { get; set; }
    }
}
