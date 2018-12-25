using System;
using System.Collections.Generic;

namespace KvitkouNet.Logic.Common.Models.UserManagement
{
    public class User
    {
        /// <summary>
        /// Уникальный номер группы
        /// </summary>
        public int Id { get; set; }

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
        /// Электронный адрес пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Список адресов пользователя 
        /// </summary>
        public IList<Address> Adress { get; set; }

        /// <summary>
        /// Секретный вопрос для восстановления пароля
        /// </summary>
        public string SecretQuestion { get; set; }

        /// <summary>
        /// Ответ на секретный вопрос
        /// </summary>
        public string SecretAnswer { get; set; }

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
        public UserGroup UserGroup { get; set; }

        /// <summary>
        /// Роли доступа пользователя
        /// </summary>
        public string UserRole { get; set; }

        /// <summary>
        /// Настройки пользователя
        /// </summary>
        public string UserSettings { get; set; }

        /// <summary>
        /// Список билетов принадлежащих пользователю
        /// </summary>
        public IList<string> Tickets { get; set; }

        /// <summary>
        /// Список карточек принадлежащих пользователю
        /// </summary>
        public IList<string> CreditCards { get; set; }
    }
}
