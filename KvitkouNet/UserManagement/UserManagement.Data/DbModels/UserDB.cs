using System;
using System.Collections.Generic;

namespace UserManagement.Data.DbModels
{
    public class UserDB
    {
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public string Id { get; set; }
        
        #region Связи между таблицами  
        /// <summary>
        /// Учетная запись пользователя
        /// </summary>
        public AccountDB Account { get; set; }

        /// <summary>
        /// Профиль пользователя
        /// </summary>
        public ProfileDB Profile { get; set; }
        #endregion 
    }
}
