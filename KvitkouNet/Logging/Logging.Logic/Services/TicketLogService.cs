using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Logging.Data;
using Logging.Data.DbModels;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;

namespace Logging.Logic.Services
{
    public class TicketLogService : ITicketLogService
    {
        protected readonly LoggingDbContext Context;
        protected readonly IMapper Mapper;

        public TicketLogService(LoggingDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public Task<IEnumerable<TicketActionLogEntry>> GetLogsAsync(TicketLogsFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task AddLogAsync(TicketActionLogEntry entry)
        {
            var dbModel = Mapper.Map<TicketActionLogEntryDbModel>(entry);

            Context.TicketActionLogEntries.Add(dbModel);

            await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
