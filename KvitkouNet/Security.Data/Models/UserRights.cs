﻿using System.Collections.Generic;

namespace Security.Data.Models
{
    /// <summary>
    /// Права пользователя
    /// </summary>
    public class UserRights
    {
        /// <summary>
        /// Идентификатор пользователя (null для незарегистрированного пользователя)
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string UserLogin { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество пользователя
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Список прав
        /// </summary>
        public List<UserRightsAccessRight> AccessRights { get; set; }

        /// <summary>
        /// Список предоставленных пользователю функций
        /// </summary>
        public List<UserRightsAccessFunction> AccessFunctions { get; set; }

        /// <summary>
        /// Список ролей пользователя
        /// </summary>
        public List<UserRightsRole> Roles { get; set; }
    }
}
