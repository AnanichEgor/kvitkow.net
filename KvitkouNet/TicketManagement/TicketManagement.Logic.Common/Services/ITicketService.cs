using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagement.Logic.Common.Models;

namespace TicketManagement.Logic.Common.Services
{
    /// <summary>
    ///     Сервис для работы с Tickets
    /// </summary>
    public interface ITicketService : IDisposable
    {
        /// <summary>
        ///     Добавляет билет
        /// </summary>
        /// <param name="ticket">Модель билета</param>
        /// <returns>Код ответа Create и добавленную модель</returns>
        Task<Ticket> Add(Ticket ticket);

        /// <summary>
        ///     Обновление информации о билете
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket">Модель билета</param>
        /// <returns></returns>
        Task<string> Update(string id, Ticket ticket);

        /// <summary>
        ///     Удаление всех билетов
        /// </summary>
        /// <returns></returns>
        Task DeleteAll();

        /// <summary>
        ///     Удаление билета с определенным Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(string id);

        /// <summary>
        ///     Получение всех билет имеющихся в системе
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Ticket>> GetAll();

        /// <summary>
        ///     Получение билета по Id
        /// </summary>
        /// <param name="ticketIdGuid">Id билета</param>
        /// <returns></returns>
        Task<Ticket> Get(string id);

        /// <summary>
        ///     Получение только актуальных билетов
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Ticket>> GetAllActual();
    }
}