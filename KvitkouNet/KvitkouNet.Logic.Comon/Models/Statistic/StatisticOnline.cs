using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models.Statistic
{  /// <summary>
   /// Статистика состояния пользователей на сайте которые Online 
   /// </summary>
    public class StatisticOnline
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
