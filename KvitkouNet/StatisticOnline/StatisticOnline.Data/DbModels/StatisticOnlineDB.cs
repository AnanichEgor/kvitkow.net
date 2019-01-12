using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticOnline.Data.Models
{
    public class StatisticOnlineDb
    {
        public int Id { get; set; }

        /// <summary>
        /// число всех пользователей на сайте Online
        /// </summary>
        public int CountAll { get; set; }

        /// <summary>
        /// число зарегистрированных пользователей
        /// </summary>
        public int CountRegistered { get; set; }

        /// <summary>
        /// число гостей на сайте Online
        /// </summary>
        public int CountGuest { get; set; }

        /// <summary>
        /// Дата и время на которую сформированы записи
        /// </summary>
        public DateTime CurrenTime { get; set; }
    }
}
