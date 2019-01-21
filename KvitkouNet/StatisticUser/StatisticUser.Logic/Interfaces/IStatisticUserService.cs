using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StatisticUser.Logic.DTOs;

namespace StatisticUser.Logic.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с StatisticUser
    /// </summary>
    public interface IStatisticUserService: IDisposable
    {
        /// <summary>
        /// Возвращает списоко ресурсов сайта и сумарного
        /// времений проведенного на них 
        /// </summary>
        /// <param name="filter">Диапазон дат</param>
        /// <returns></returns>
        Task<IEnumerable<ITimeOnResouces>> GetTimeOnResouces(DateRange filter);


    }
}
