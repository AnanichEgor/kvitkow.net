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
    public class DealLogService : IDealLogService
    {
        protected readonly LoggingDbContext Context;
        protected readonly IMapper Mapper;

        public DealLogService(LoggingDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public Task<IEnumerable<TicketDealLogEntry>> GetLogsAsync(TicketLogsFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task AddLogAsync(TicketDealLogEntry entry)
        {
            var dbModel = Mapper.Map<TicketDealLogEntryDbModel>(entry);

            Context.TicketDealLogEntries.Add(dbModel);

            await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
