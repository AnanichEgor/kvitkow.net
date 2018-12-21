using System;
using System.Collections.Generic;

namespace KvitkouNet.Logic.Common.Models.UserManagement
{
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        public Account Account { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}
