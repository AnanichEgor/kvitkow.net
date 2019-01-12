using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticOnline.Logic.Interfaces
{
    public interface IStatisticOnlineService: IDisposable
    {
        /// <summary>
        /// число всех пользователей на сайте Online
        /// </summary>
        Task<int> GetAllUsers();

        /// <summary>
        /// число зарегистрированных пользователей
        /// </summary>
        Task<int> GetRegisteredUser();

        /// <summary>
        /// число гостей на сайте Online
        /// </summary>
        Task<int> GetGuestUser();
    }
}
