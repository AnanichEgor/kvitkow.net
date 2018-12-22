using KvitkouNet.Logic.Common.Models.Security;
using System.Collections.Generic;

namespace KvitkouNet.Logic.Common.Models.UserManagement
{
    public class Group
    {
        /// <summary>
        /// Уникальный номер группы
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя группы
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание назначения группы
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Пользователи группы
        /// </summary>
        public ICollection<User> GroupUsers { get; set; }

        /// <summary>
        /// Роли группы
        /// </summary>
        public ICollection<Role> GroupRoles { get; set; }
    }
}
