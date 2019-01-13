using System;
using System.Collections.Generic;
using UserManagement.Data.DbModels.Security;
using UserManagement.Data.DbModels.Tickets;

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
        public AccountDB AccountDB { get; set; }

        /// <summary>
        /// Профиль пользователя
        /// </summary>
        public ProfileDB ProfileDB { get; set; }

        /// <summary>
        /// Группы, в которых состоит пользователь
        /// </summary>
        public ICollection<UserGroupDB> UserGroups { get; set; }

        /// <summary>
        /// Роли доступа пользователя
        /// </summary>
        public ICollection<RoleDB> UserRoles { get; set; }

        /// <summary>
        /// Список билетов принадлежащих пользователю
        /// </summary>
        public ICollection<TicketDB> Tickets { get; set; }
        #endregion 
    }
}
