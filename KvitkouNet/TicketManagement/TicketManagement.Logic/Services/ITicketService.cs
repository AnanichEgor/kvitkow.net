using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagement.Logic.Models;
using TicketManagement.Logic.Models.Enums;

namespace TicketManagement.Logic.Services
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
        Task<(string, RequestStatus)> Add(Ticket ticket);

        /// <summary>
        ///     Обновление информации о билете
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket">Модель билета</param>
        /// <returns></returns>
        Task<RequestStatus> Update(string id, Ticket ticket);

        /// <summary>
        ///     Удаление всех билетов
        /// </summary>
        /// <returns></returns>
        Task<RequestStatus> DeleteAll();

        /// <summary>
        ///     Удаление билета с определенным Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RequestStatus> Delete(string id);

        /// <summary>
        ///     Получение всех билет имеющихся в системе
        /// </summary>
        /// <returns></returns>
        Task<(IEnumerable<Ticket>, RequestStatus)> GetAll();

        /// <summary>
        ///     Получение билета по Id
        /// </summary>
        /// <param name="ticketIdGuid">Id билета</param>
        /// <returns></returns>
        Task<(Ticket, RequestStatus)> Get(string id);

        /// <summary>
        ///     Получение только актуальных билетов
        /// </summary>
        /// <returns></returns>
        Task<(IEnumerable<Ticket>, RequestStatus)> GetAllActual();

        /// <summary>
        ///     Получение всех билетов имеющихся в системе постранично
        /// </summary>
        /// <param name="index"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<(Page<TicketLite>, RequestStatus)> GetAllPagebyPage(int index);
    }
}