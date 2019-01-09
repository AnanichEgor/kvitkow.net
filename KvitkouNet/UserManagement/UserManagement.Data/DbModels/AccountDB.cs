using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Data.DbModels
{
    public class AccountDB
    {
        /// <summary>
        /// Уникальный идентификатор учетной записи
        /// </summary>
        public string Id { get; set; }

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

        #region Связи между таблицами  
        /// <summary>
        /// Пользователь
        /// </summary>
        public UserDB UserDB { get; set; }
        #endregion
    }
}
