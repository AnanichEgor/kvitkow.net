using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Data.Context;
using TicketManagement.Logic.Models;

namespace TicketManagement.Logic.Services
{
    public class TicketService : ITicketService
    {

        private readonly TicketContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator _validator;

        public TicketService(TicketContext context, IMapper mapper, IValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;

        }

        /// <summary>
        ///     Добавляет билет
        /// </summary>
        /// <param name="ticket">Модель билета</param>
        /// <returns>Код ответа Create и добавленную модель</returns>

        public Task<Ticket> Add(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Обновление информации о билете
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket">Модель билета</param>
        /// <returns></returns>
        public Task<string> Update(string id, Ticket ticket)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Удаление всех билетов
        /// </summary>
        /// <returns></returns>
        public Task DeleteAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Удаление билета с определенным Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Получение всех билет имеющихся в системе
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Ticket>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Получение билета по Id
        /// </summary>
        /// <param name="ticketIdGuid">Id билета</param>
        /// <returns></returns>
        public Task<Ticket> Get(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Получение только актуальных билетов
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Ticket>> GetAllActual()
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

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
