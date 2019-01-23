using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Logging.Data;
using Logging.Data.DbModels;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;
using Microsoft.EntityFrameworkCore;

namespace Logging.Logic.Services
{
    public class ErrorLogService : IErrorLogService
    {
        protected readonly LoggingDbContext Context;
        protected readonly IMapper Mapper;

        public ErrorLogService(LoggingDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
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

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
