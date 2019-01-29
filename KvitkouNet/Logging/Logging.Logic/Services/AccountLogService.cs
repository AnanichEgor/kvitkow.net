using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Logging.Data;
using Logging.Data.DbModels;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;
using Logging.Logic.Services.Abstraction;

namespace Logging.Logic.Services
{
    public class AccountLogService : BaseService, IAccountLogService
    {
        public AccountLogService(LoggingDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public Task<IEnumerable<AccountLogEntry>> GetLogsAsync(AccountLogsFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task AddLogAsync(AccountLogEntry entry)
        {
            var dbModel = Mapper.Map<AccountLogEntryDbModel>(entry);

            Context.AccountLogEntries.Add(dbModel);

            await Context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
