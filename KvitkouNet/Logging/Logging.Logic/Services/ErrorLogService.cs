using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logging.Data;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;

namespace Logging.Logic.Services
{
    public class ErrorLogService : IErrorLogService
    {
        protected readonly LoggingDbContext Context;

        public ErrorLogService(LoggingDbContext context)
        {
            Context = context;
        }

        public Task<IEnumerable<InternalErrorLogEntry>> GetLogsAsync(ErrorLogsFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task AddLogAsync(InternalErrorLogEntry entry)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
