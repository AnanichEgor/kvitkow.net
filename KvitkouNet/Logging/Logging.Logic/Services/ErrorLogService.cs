using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Logging.Data;
using Logging.Data.DbModels;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;
using Logging.Logic.Services.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Logging.Logic.Services
{
    public class ErrorLogService : BaseService, IErrorLogService
    {
        public ErrorLogService(LoggingDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public async Task<IEnumerable<InternalErrorLogEntry>> GetLogsAsync(ErrorLogsFilter filter)
        {
            var dbModels = await Context.InternalErrorLogEntries.ToListAsync().ConfigureAwait(false);

            return Mapper.Map<IEnumerable<InternalErrorLogEntry>>(dbModels);
        }

        public async Task AddLogAsync(InternalErrorLogEntry entry)
        {
            var dbModel = Mapper.Map<InternalErrorLogEntryDbModel>(entry);

            Context.InternalErrorLogEntries.Add(dbModel);

            await Context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
