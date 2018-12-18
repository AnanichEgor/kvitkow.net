using System;
using System.Collections.Generic;

namespace KvitkouNet.Logic.Common.Models.Security
{
    /// <summary>
    /// Роль
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя роли
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список предоставляемых прав
        /// </summary>
        public List<AccessRight> AccessRights { get; set; }

        /// <summary>
        /// Список запрещённых прав
        /// </summary>
        public List<AccessRight> DeniedRights { get; set; }

        /// <summary>
        /// Список предоставляемых функций
        /// </summary>
        public List<AccessFunction> AccessFunctions { get; set; }
    }
}
