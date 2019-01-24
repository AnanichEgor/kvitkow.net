using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using TicketManagement.Data.DbModels;
using TicketManagement.Data.Repositories;
using TicketManagement.Logic.Models;
using TicketManagement.Logic.Models.Enums;

namespace TicketManagement.Logic.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _context;
        private readonly IMapper _mapper;
        private readonly IValidator _validator;
        private readonly IConfiguration _configuration;

        public TicketService(ITicketRepository context, IMapper mapper, IValidator<Ticket> validator, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
            _configuration = configuration;
        }

        /// <summary>
        ///     Добавляет билет
        /// </summary>
        /// <param name="ticket">Модель билета</param>
        /// <returns>Код ответа Create и добавленную модель</returns>
        public async Task<(string, RequestStatus)> Add(Ticket ticket)
        {
            if (!_validator.Validate(ticket).IsValid) return (null, RequestStatus.BadRequest);
            var res = await _context.Add(_mapper.Map<TicketDb>(ticket));
            return (res, RequestStatus.Success);
        }

        /// <summary>
        ///     Обновление информации о билете
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket">Модель билета</param>
        /// <returns></returns>
        public async Task<RequestStatus> Update(string id, Ticket ticket)
        {
            await _context.Update(id, _mapper.Map<TicketDb>(ticket));
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
        public async Task<(IEnumerable<Ticket>, RequestStatus)> GetAll()
        {
            var res = _mapper.Map<IEnumerable<Ticket>>(await _context.GetAll());
            return res == null ? (null, RequestStatus.Error) : (res, RequestStatus.Success);
        }

        /// <summary>
        ///     Получение билета по Id
        /// </summary>
        /// <param name="ticketIdGuid">Id билета</param>
        /// <returns></returns>
        public async Task<(Ticket, RequestStatus)> Get(string id)
        {
            var res = await _context.Get(id);
            return res == null ? (null, RequestStatus.BadRequest) : (_mapper.Map<Ticket>(res), RequestStatus.Success);
        }

        /// <summary>
        ///     Получение только актуальных билетов
        /// </summary>
        /// <returns></returns>
        public async Task<(IEnumerable<Ticket>, RequestStatus)> GetAllActual()
        {
            var res = await _context.GetAllActual();
            return res == null
                ? (null, RequestStatus.BadRequest)
                : (_mapper.Map<IEnumerable<Ticket>>(res), RequestStatus.Success);
        }

        /// <summary>
        ///     Получение всех билетов имеющихся в системе постранично
        /// </summary>
        /// <param name="index"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<(Models.Page<TicketLite>, RequestStatus)> GetAllPagebyPage(int index)
        {
            var pageSize = _configuration.GetValue<int>("pageSize");
            var res = await _context.GetAllPagebyPage(index, pageSize);
            return res == null
                ? (null, RequestStatus.BadRequest)
                : (_mapper.Map<Models.Page<TicketLite>>(res), RequestStatus.Success);
        }

        #region IDisposable Support

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}