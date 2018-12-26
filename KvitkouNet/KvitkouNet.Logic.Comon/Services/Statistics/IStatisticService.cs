using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.Statistic;
using UserManagement = KvitkouNet.Logic.Common.Models.UserManagement;

namespace KvitkouNet.Logic.Common.Services.Statistics
{
    /// <summary>
    /// Statistics service
    /// Сервис статисктики
    /// </summary>
    public interface IStatisticService:IDisposable
    {
        /// <summary>
        /// Shows statistics to owner
        /// Показывает статистику пользователю
        /// </summary>
        /// <returns></returns>
        Task<OwnStatistic> GetOwnStatistic();

        /// <summary>
        /// Adds ticket to list of realised tickets
        /// Добавляет билет в список проданных билетов
        /// </summary>
        /// <param name="offer"></param>
        /// <returns></returns>
        Task<OwnStatistic> AddRealisedTicket(Offer offer);

        /// <summary>
        /// Adds ticket to list of donated tickets
        /// Добавляет билет в список подаренных билетов
        /// </summary>
        /// <param name="offer"></param>
        /// <returns></returns>
        Task<OwnStatistic> AddDonatedTicket(Offer offer);

        /// <summary>
        /// Edit total offers by owner
        /// Показывает общее количество сделок, совершенных пользователем
        /// </summary>
        /// <returns></returns>
        Task<OwnStatistic> EditTotalOffers();

        /// <summary>
        /// Edit banned users by owner
        /// Показывает список пользователей, попавших в черный список пользователя
        /// </summary>
        /// <returns></returns>
        Task<OwnStatistic> EditBlackList();

        /// <summary>
        /// Adds some user from owner`s black list
        /// Добавляет какого-то пользователя в черный список пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<OwnStatistic> AddToBlackList(UserManagement.User user);

        /// <summary>
        /// Removes some user from owner`s black list
        /// Удаляет какого-то пользователя из черного списка пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<OwnStatistic> DeleteFromBlackList(UserManagement.User user);
    }
}
