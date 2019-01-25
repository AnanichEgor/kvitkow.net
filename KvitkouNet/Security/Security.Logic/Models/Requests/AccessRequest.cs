namespace Security.Logic.Models.Requests
{
    public class AccessRequest
    {
        public string UserId { get; set; }

        /// <summary>
        /// Имена запрашиваемых для проверки прав
        /// </summary>
        public string[] AccessRightNames { get; set; }
    }
}
