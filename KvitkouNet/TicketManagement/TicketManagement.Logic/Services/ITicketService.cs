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
        Task<(string, ResponseModel)> Add(Ticket ticket);

        /// <summary>
        ///     Обновление информации о билете
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket">Модель билета</param>
        /// <returns></returns>
        Task<ResponseModel> Update(string id, Ticket ticket);

        /// <summary>
        ///     Добавление пользователя в "я пойду"
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket">Модель билета</param>
        /// <returns></returns>
        Task<ResponseModel> AddRespondedUsers(string id, UserInfo user);

        /// <summary>
        ///     Удаление всех билетов
        /// </summary>
        /// <returns></returns>
        Task<ResponseModel> DeleteAll();

        /// <summary>
        ///     Удаление билета с определенным Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseModel> Delete(string id);

        /// <summary>
        ///     Получение всех билет имеющихся в системе
        /// </summary>
        /// <returns></returns>
        Task<(IEnumerable<Ticket>, ResponseModel)> GetAll();

        /// <summary>
        ///     Получение билета по Id
        /// </summary>
        /// <returns></returns>
        Task<(Ticket, ResponseModel)> Get(string id);

        /// <summary>
        ///     Получение только актуальных билетов
        /// </summary>
        /// <returns></returns>
        Task<(IEnumerable<Ticket>, ResponseModel)> GetAllActual();

        /// <summary>
        ///     Получение всех билетов имеющихся в системе постранично
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        Task<(Page<TicketLite>, ResponseModel)> GetAllPagebyPage(int index);

        /// <summary>
        ///     Получение всех актуальных билетов имеющихся в системе постранично
        /// </summary>
        /// <param name="index"></param>
        /// <param name="onlyActual">Только актуальные билеты</param>
        /// <returns></returns>
        Task<(Page<TicketLite>, ResponseModel)> GetAllPagebyPageActual(int index, bool onlyActual=true);
    }
}