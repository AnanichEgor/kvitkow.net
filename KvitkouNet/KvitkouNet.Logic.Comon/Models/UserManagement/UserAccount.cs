using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models.UserManagement
{
    public class UserAccount
    {
        /// <summary>
        /// Уникальный идентификатор учетной записи
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string UserLogin { get; set; }

        /// <summary>
        /// Электронный адрес пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Секретный вопрос для восстановления пароля
        /// </summary>
        public string SecretQuestion { get; set; }

        /// <summary>
        /// Ответ на секретный вопрос
        /// </summary>
        public string SecretAnswer { get; set; }
    }
}
