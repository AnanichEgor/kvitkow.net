using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KvitkouNet.Web.Models.UserManagement
{
    public class UserModelForView
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string UserLogin { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public string Sex { get; set; }

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
