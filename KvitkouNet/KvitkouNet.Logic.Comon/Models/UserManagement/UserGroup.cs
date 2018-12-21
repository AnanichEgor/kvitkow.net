﻿using KvitkouNet.Logic.Common.Models.Security;
using System.Collections.Generic;

namespace KvitkouNet.Logic.Common.Models.UserManagement
{
    public class UserGroup
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
        public IList<User> GroupUsers { get; set; }

        /// <summary>
        /// Роли группы
        /// </summary>
        public IList<Role> GroupRoles { get; set; }
    }
}
