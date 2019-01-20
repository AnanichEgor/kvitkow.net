using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logging.Data;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;

namespace Logging.Logic.Services
{
    public class DealLogService : IDealLogService
    {
        protected readonly LoggingDbContext Context;

        public DealLogService(LoggingDbContext context)
        {
            Context = context;
        }

        public Task<IEnumerable<TicketDealLogEntry>> GetLogsAsync(TicketLogsFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task AddLogAsync(TicketDealLogEntry entry)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
