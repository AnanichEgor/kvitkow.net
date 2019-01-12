using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticOnline.Logic.Models
{
    /// <summary>
    /// Статистика состояния пользователей на сайте которые Online 
    /// </summary>
    public class OnlineModel
    {
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
    }
}
