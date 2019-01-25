using System.Collections.Generic;

namespace Security.Logic.Models.Responses
{
    public class AccessResponse : ActionResponse
    {
        public string UserId { get; set; }

        /// <summary>
        /// Имена запрашиваемых для проверки прав
        /// </summary>
        public Dictionary<string, bool> AccessRightNames { get; set; }
    }
}
