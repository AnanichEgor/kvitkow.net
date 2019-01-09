using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UserManagement.Logic.Models.Security;
using UserManagement.Logic.Models.Tickets;
using UserManagement.Logic.Models.UserSettings;

namespace UserManagement.Data.DbModels
{
    public class ProfileDB
    {
        /// <summary>
        /// Уникальный идентификатор профиля пользователя
        /// </summary>
        public string Id { get; set; }

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
        /// Пол
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; }


        #region Поля для редактирования администратором 
        /// <summary>
        /// Рейтинг пользователя
        /// </summary>
        public double Rating { get; set; }

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
        #endregion

        #region Связи между таблицами  
        /// <summary>
        /// Пользователь
        /// </summary>
        public UserDB UserDB { get; set; }

        /// <summary>
        /// Настройки пользователя
        /// </summary>
        public ProfileSettings UserSettings { get; set; }

        /// <summary>
        /// Список адресов пользователя 
        /// </summary>
        public ICollection<AddressDB> Adresses { get; set; }

        /// <summary>
        /// Список телефонов пользователя
        /// </summary>
        public ICollection<PhoneNumberDB> PhoneNumbers { get; set; }

        /// <summary>
        /// Группы, в которых состоит пользователь
        /// </summary>
        public ICollection<GroupDB> UserGroups { get; set; }

        /// <summary>
        /// Роли доступа пользователя
        /// </summary>
        public ICollection<Role> UserRoles { get; set; }

        /// <summary>
        /// Список билетов принадлежащих пользователю
        /// </summary>
        public ICollection<Ticket> Tickets { get; set; }
        #endregion
    }
}

