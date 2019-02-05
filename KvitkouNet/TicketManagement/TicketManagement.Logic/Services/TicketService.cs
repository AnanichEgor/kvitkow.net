using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using EasyNetQ;
using FluentValidation;
using KvitkouNet.Messages.TicketManagement;
using Microsoft.Extensions.Configuration;
using Polly;
using TicketManagement.Data.DbModels;
using TicketManagement.Data.Repositories;
using TicketManagement.Logic.Extentions;
using TicketManagement.Logic.Models;
using TicketManagement.Logic.Models.Enums;
using Ticket = TicketManagement.Data.DbModels.Ticket;
using UserInfo = TicketManagement.Logic.Models.UserInfo;

namespace TicketManagement.Logic.Services
{
    /// <summary>
    ///     Сервис для работы с тикетами
    /// </summary>
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _context;
        private readonly IMapper _mapper;
        private readonly IValidator _validatorTickets;
        private readonly IConfiguration _configuration;
        private readonly IBus _bus;
        private readonly IValidator<UserInfo> _validatorUsers;

        public TicketService(ITicketRepository context, IMapper mapper, IValidator<Models.Ticket> validatorTickets,
            IConfiguration configuration, IBus bus, IValidator<Models.UserInfo> validatorUsers)
        {
            _context = context;
            _mapper = mapper;
            _validatorTickets = validatorTickets;
            _configuration = configuration;
            _bus = bus;
            _validatorUsers = validatorUsers;
        }

        /// <summary>
        ///     Добавляет билет
        /// </summary>
        /// <param name="ticket">Модель билета</param>
        /// <returns>Код ответа Create и добавленную модель</returns>
        public async Task<ResponseModel> Add(Models.Ticket ticket)
        {
            //WARNING используется для замены стандартных значений swagerr'a
            //при связи с фронтом надо убрать 
            ticket.SellerPhone = "+375-29-76-23-371";
            //WARNING

            if (ticket.User.Rating < 0) return (null, RequestStatus.BadUserRating);
            if (!_validator.Validate(ticket).IsValid) return (null, RequestStatus.InvalidModel);
            var res = await _context.Add(_mapper.Map<Ticket>(ticket));
            await _bus.PublishAsync(new TicketCreationMessage
            var policy = Policy.Handle<TimeoutException>().WaitAndRetryAsync(new[] {TimeSpan.FromSeconds(1)});
            {
                TicketId = res,
                Price = ticket.Price,
                Name = ticket.Name,
                City = ticket.LocationEvent.City,
                Category = ticket.TypeEvent.ToString(),
                Date = DateTime.Now
            });
            return (res, RequestStatus.Success);
        }

        /// <summary>
        ///     Обновление информации о билете
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket">Модель билета</param>
        /// <returns></returns>
        public async Task<ResponseModel> Update(string id, Models.Ticket ticket)
        {
            await _context.Update(id, _mapper.Map<Ticket>(ticket));
            await _bus.PublishAsync(new TicketUpdatedMessage()
            var policy = Policy.Handle<TimeoutException>().WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(1) });
            {
                TicketId = id,
                Price = ticket.Price,
                Name = ticket.Name,
                City = ticket.LocationEvent.City,
                Category = ticket.TypeEvent.ToString(),
                Date = DateTime.Now
            });
            return RequestStatus.Success;
        }

        /// <summary>
        ///     Добавление пользователя в "я пойду"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseModel> AddRespondedUsers(string id, UserInfo user)
        {
            if (!_validator.Validate(user).IsValid) return RequestStatus.InvalidModel;
            await _context.AddRespondedUsers(id, _mapper.Map<Data.DbModels.UserInfo>(user));
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
        public async Task<ResponseModel> Delete(string id)
        {
            await _context.Delete(id);
            await _bus.PublishAsync(new TicketDeletedMessage
            var policy = Policy.Handle<TimeoutException>().WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(1) });
            {
               TicketId = id
            });
            return RequestStatus.Success;
        }

        /// <summary>
        ///     Получение всех билет имеющихся в системе
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseModel> GetAll()
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
        public async Task<ResponseModel> GetAllActual()
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
        public async Task< ResponseModel> GetAllPagebyPage(int index)
        {
            var pageSize = _configuration.GetValue<int>("pageSize");
            var res = await _context.GetAllPagebyPage(index, pageSize);
            return res == null
                ? (null, RequestStatus.Error)
                : (_mapper.Map<Models.Page<TicketLite>>(res), RequestStatus.Success);
        }

        /// <summary>
        ///     Получение всех актуальных билетов имеющихся в системе постранично
        /// </summary>
        /// <param name="index">Номер текущей страницы</param>
        /// <param name="onlyActual">Только актуальные билеты</param>
        /// <returns></returns>
        public async Task< ResponseModel> GetAllPagebyPageActual(int index, bool onlyActual = true)
        {
            var pageSize = _configuration.GetValue<int>("pageSize");
            var res = await _context.GetAllPagebyPage(index, pageSize,onlyActual);
            return res == null
                ? (null, RequestStatus.Error)
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