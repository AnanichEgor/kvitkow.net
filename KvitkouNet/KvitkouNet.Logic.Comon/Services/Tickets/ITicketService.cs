using System;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.Tickets;
using Microsoft.AspNetCore.Mvc;

namespace KvitkouNet.Logic.Common.Services.Tickets
{
    /// <summary>
    /// Сервис для работы с Tickets
    /// </summary>
    public interface ITicketService : IDisposable
    {
        /// <summary>
        ///     Добавляет билет
        /// </summary>
        /// <param name="ticket">Модель билета</param>
        /// <returns>Код ответа Create и добавленную модель</returns>
        Task<IActionResult> Add(Ticket ticket);

        /// <summary>
        ///     Обновление информации о билете
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket">Модель билета</param>
        /// <returns></returns>
        Task<IActionResult> Update(string id, Ticket ticket);

        /// <summary>
        ///     Удаление всех билетов
        /// </summary>
        /// <returns></returns>
        Task<IActionResult> DeleteAll();

        /// <summary>
        ///     Удаление билета с определенным Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IActionResult> Delete(string id);

        /// <summary>
        ///     Получение всех билет имеющихся в системе
        /// </summary>
        /// <returns></returns>
        Task<IActionResult> GetAll();

        /// <summary>
        ///     Получение билета по Id
        /// </summary>
        /// <param name="ticketIdGuid">Id билета</param>
        /// <returns></returns>
        Task<IActionResult> Get(string id);

        /// <summary>
        ///     Получение только актуальных билетов
        /// </summary>
        /// <returns></returns>
        Task<IActionResult> GetAllActual();
    }
}