using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KvitkouNet.Logic.Common.Models.UserManagement
{
    public class ForUpdateModel
    {
        /// <summary>     
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Список адрессов пользователя
        /// </summary>
        public ICollection<string> Adress { get; set; }

        /// <summary>
        /// Список телефонов пользователя
        /// </summary>
        public ICollection<string> Phones { get; set; }

        /// <summary>
        /// Пол пользователя
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// Дата рождения пользователя
        /// </summary>
        public DateTime Birthday { get; set; }
    }
}
