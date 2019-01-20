using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logging.Data;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;

namespace Logging.Logic.Services
{
    public class TicketLogService : ITicketLogService
    {
        protected readonly LoggingDbContext Context;

        public TicketLogService(LoggingDbContext context)
        {
            Context = context;
        }

        public Task<IEnumerable<TicketActionLogEntry>> GetLogsAsync(TicketLogsFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task AddLogAsync(TicketActionLogEntry entry)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
