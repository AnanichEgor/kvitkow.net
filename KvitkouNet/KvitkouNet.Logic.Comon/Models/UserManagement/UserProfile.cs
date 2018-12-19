﻿using KvitkouNet.Logic.Common.Models.Security;
using System;
using System.Collections.Generic;

namespace KvitkouNet.Logic.Common.Models.UserManagement
{
    public class UserProfile
    {
        /// <summary>
        /// Уникальный идентификатор профиля пользователя
        /// </summary>
        public Guid UserId { get; set; }

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
        /// Список адресов пользователя 
        /// </summary>
        public IList<Address> Adress { get; set; }

        /// <summary>
        /// Список телефонов пользователя
        /// </summary>
        public IList<string> Mobile { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// Возраст пользователя
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Статус блокировки
        /// </summary>
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Пометка на удаление пользователя
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// Проверен ли пользователь администратором
        /// </summary>
        public bool IsVerified { get; set; }

        /// <summary>
        /// Группы, в которых состоит пользователь
        /// </summary>
        public IList<UserGroup> UserGroups { get; set; }

        /// <summary>
        /// Роли доступа пользователя
        /// </summary>
        public IList<Role> UserRoles { get; set; }

        /// <summary>
        /// Настройки пользователя
        /// </summary>
        public UserSettings UserSettings { get; set; }

        /// <summary>
        /// Список билетов принадлежащих пользователю
        /// </summary>
        public IList<string> Tickets { get; set; }

        /// <summary>
        /// Список карточек принадлежащих пользователю
        /// </summary>
        public IList<string> CreditCards { get; set; }

        /// <summary>
        /// Gets or sets the user rating.
        /// </summary>
        public double Rating { get; set; }
    }
}
