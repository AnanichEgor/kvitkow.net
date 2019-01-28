using System;

namespace UserManagement.Logic.Models
{
    public class ForViewModel
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Рейтинг пользователя
        /// </summary>
        public double Rating { get; set; }
    }
}
