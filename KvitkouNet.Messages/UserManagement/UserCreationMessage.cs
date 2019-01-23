using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Messages.UserManagement
{
    /// <summary>
    /// Модель сообщения о создании нового пользователя
    /// </summary>
    public class UserCreationMessage
    {
        /// <summary>
        /// Имя нового пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Дата и время создания нового пользователя
        /// </summary>
        public DateTime Created { get; set; }
    }
}
