using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EasyNetQ;
using FluentValidation;
using KvitkouNet.Messages.TicketManagement;
using Microsoft.Extensions.Configuration;
using TicketManagement.Data.DbModels;
using TicketManagement.Data.Repositories;
using TicketManagement.Logic.Extentions;
using TicketManagement.Logic.Models;
using TicketManagement.Logic.Models.Enums;
using Ticket = TicketManagement.Data.DbModels.Ticket;

namespace TicketManagement.Logic.Services
{
    /// <summary>
    ///     Сервис для работы с тикетами
    /// </summary>
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _context;
        private readonly IMapper _mapper;
        private readonly IValidator _validator;
        private readonly IConfiguration _configuration;
        private readonly IBus _bus;

        public TicketService(ITicketRepository context, IMapper mapper, IValidator<Models.Ticket> validator,
            IConfiguration configuration, IBus bus)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
            _configuration = configuration;
            _bus = bus;
        }

        /// <summary>
        ///     Добавляет билет
        /// </summary>
        /// <param name="ticket">Модель билета</param>
        /// <returns>Код ответа Create и добавленную модель</returns>
        public async Task<(string, RequestStatus)> Add(Models.Ticket ticket)
        {
            //WARNING используется для замены стандартных значений swagerr'a
            //при связи с фронтом надо убрать 
            ticket.SellerPhone = "+375-29-76-23-371";
            //WARNING

            if (ticket.User.Rating < 0) return (null, RequestStatus.BadUserRating);
            if (!_validator.Validate(ticket).IsValid) return (null, RequestStatus.InvalidModel);
            if (!ticket.PhoneValidate()) return (null, RequestStatus.InvalidModel);
            var res = await _context.Add(_mapper.Map<Ticket>(ticket));
            await _bus.PublishAsync(new TicketCreateMessage
            {
                TicketId = res, Create = DateTime.Now, UserId = ticket.User.UserInfoId
            });
            return (res, RequestStatus.Success);
        }

        /// <summary>
        ///     Обновление информации о билете
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket">Модель билета</param>
        /// <returns></returns>
        public async Task<RequestStatus> Update(string id, Models.Ticket ticket)
        {
            await _context.Update(id, _mapper.Map<Ticket>(ticket));
            return RequestStatus.Success;
        }

        /// <summary>
        ///     Удаление всех билетов
        /// </summary>
        /// <returns></returns>
        public async Task<RequestStatus> DeleteAll()
        {
            await _context.DeleteAll();
            return RequestStatus.Success;
        }

        /// <summary>
        ///     Удаление билета с определенным Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RequestStatus> Delete(string id)
        {
            await _context.Delete(id);
            return RequestStatus.Success;
        }

        /// <summary>
        ///     Получение всех билет имеющихся в системе
        /// </summary>
        /// <returns></returns>
        public async Task<(IEnumerable<Models.Ticket>, RequestStatus)> GetAll()
        {
            var res = _mapper.Map<IEnumerable<Models.Ticket>>(await _context.GetAll());
            return res == null ? (null, RequestStatus.Error) : (res, RequestStatus.Success);
        }

        /// <summary>
        ///     Получение билета по Id
        /// </summary>
        /// <returns></returns>
        public async Task<(Models.Ticket, RequestStatus)> Get(string id)
        {
            var res = await _context.Get(id);
            return res == null ? (null, RequestStatus.InvalidModel) : (_mapper.Map<Models.Ticket>(res), RequestStatus.Success);
        }

        /// <summary>
        ///     Получение только актуальных билетов
        /// </summary>
        /// <returns></returns>
        public async Task<(IEnumerable<Models.Ticket>, RequestStatus)> GetAllActual()
        {
            var res = await _context.GetAllActual();
            return res == null
                ? (null, RequestStatus.InvalidModel)
                : (_mapper.Map<IEnumerable<Models.Ticket>>(res), RequestStatus.Success);
        }

        /// <summary>
        ///     Получение всех билетов имеющихся в системе постранично
        /// </summary>
        /// <param name="index">Номер текущей страницы</param>
        /// <returns></returns>
        public async Task<(Models.Page<TicketLite>, RequestStatus)> GetAllPagebyPage(int index)
        {
            var pageSize = _configuration.GetValue<int>("pageSize");
            var res = await _context.GetAllPagebyPage(index, pageSize);
            return res == null
                ? (null, RequestStatus.InvalidModel)
                : (_mapper.Map<Models.Page<TicketLite>>(res), RequestStatus.Success);
        }

        /// <summary>
        ///     Получение всех актуальных билетов имеющихся в системе постранично
        /// </summary>
        /// <param name="index">Номер текущей страницы</param>
        /// <param name="onlyActual">Только актуальные билеты</param>
        /// <returns></returns>
        public async Task<(Models.Page<TicketLite>, RequestStatus)> GetAllPagebyPageActual(int index, bool onlyActual = true)
        {
            var pageSize = _configuration.GetValue<int>("pageSize");
            var res = await _context.GetAllPagebyPage(index, pageSize,onlyActual);
            return res == null
                ? (null, RequestStatus.InvalidModel)
                : (_mapper.Map<Models.Page<TicketLite>>(res), RequestStatus.Success);
        }

        /// <summary>
        ///     Disposing
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}