using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
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
        private RequestStatus _requestStatus;

        public TicketService(ITicketRepository context, IMapper mapper, IValidator<Ticket> validator, RequestStatus requestStatus)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
            _requestStatus = requestStatus;
        }

        /// <summary>
        ///     Добавляет билет
        /// </summary>
        /// <param name="ticket">Модель билета</param>
        /// <returns>Код ответа Create и добавленную модель</returns>
        public async Task<(string, RequestStatus)> Add(Ticket ticket)
        {
            if (!_validator.Validate(ticket).IsValid)
            {
                return (null,RequestStatus.BadRequest);
            }
            var res = await _context.Add(_mapper.Map<TicketDb>(ticket));
            return (res,RequestStatus.Success);
        }

        /// <summary>
        ///     Обновление информации о билете
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket">Модель билета</param>
        /// <returns></returns>
        public Task<RequestStatus> Update(string id, Ticket ticket)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Удаление всех билетов
        /// </summary>
        /// <returns></returns>
        public Task<RequestStatus> DeleteAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Удаление билета с определенным Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<RequestStatus> Delete(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Получение всех билет имеющихся в системе
        /// </summary>
        /// <returns></returns>
        public async Task<(IEnumerable<Ticket>, RequestStatus)> GetAll()
        {
            var res = _mapper.Map<IEnumerable<Ticket>>(await _context.GetAll());
            if (res == null) return (null, RequestStatus.Error);
            return (res,RequestStatus.Success);
        }

        /// <summary>
        ///     Получение билета по Id
        /// </summary>
        /// <param name="ticketIdGuid">Id билета</param>
        /// <returns></returns>
        public Task<(Ticket, RequestStatus)> Get(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Получение только актуальных билетов
        /// </summary>
        /// <returns></returns>
        public Task<(IEnumerable<Ticket>, RequestStatus)> GetAllActual()
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support

        private bool disposedValue; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~TicketService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}