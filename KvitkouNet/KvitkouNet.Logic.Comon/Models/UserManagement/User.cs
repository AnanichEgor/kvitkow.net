using System;
using System.Collections.Generic;

namespace KvitkouNet.Logic.Common.Models.UserManagement
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
        public UserProfile UserProfile { get; set; }
    }
}
