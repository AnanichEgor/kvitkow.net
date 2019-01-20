using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Logging.Data;
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
            return Mapper.Map<InternalErrorLogEntry[]>(await Context.InternalErrorLogEntries.AsNoTracking().ToArrayAsync());
        }

        public async Task AddLogAsync(InternalErrorLogEntry entry)
        {
            await Context.AddAsync(entry);
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
