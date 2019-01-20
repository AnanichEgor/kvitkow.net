using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logging.Data;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;

namespace Logging.Logic.Services
{
    public class AccountLogService : IAccountLogService
    {
        protected readonly LoggingDbContext Context;

        public AccountLogService(LoggingDbContext context)
        {
            Context = context;
        }

        public Task<IEnumerable<AccountLogEntry>> GetLogsAsync(AccountLogsFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task AddLogAsync(AccountLogEntry entry)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
