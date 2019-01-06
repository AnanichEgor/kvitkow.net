using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Logic.Common.Models
{
    public class Account
    {
        /// <summary>
        /// Уникальный идентификатор учетной записи
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Электронный адрес пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }
    }
}
