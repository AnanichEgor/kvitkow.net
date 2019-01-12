using System.Collections.Generic;

namespace Security.Data.Models
{
    /// <summary>
    /// Роль
    /// </summary>
    internal class Role
    {
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя роли
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список прав
        /// </summary>
        public List<RoleAccessRight> AccessRights { get; set; }

        /// <summary>
        /// Список предоставляемых функций
        /// </summary>
        public List<RoleAccessFunction> AccessFunctions { get; set; }
    }
}
