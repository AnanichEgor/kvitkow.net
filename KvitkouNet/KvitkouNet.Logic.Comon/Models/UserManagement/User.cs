using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models.UserManagement
{
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        public UserAccount UserAccount { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}
