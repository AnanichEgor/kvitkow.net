using System;
using System.Collections.Generic;

namespace UserManagement.Logic.Common.Models
{
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Учетная запись пользователя
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Профиль пользователя
        /// </summary>
        public Profile Profile { get; set; }
    }
}
