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
    public class TicketLogService : BaseService, ITicketLogService
    {
        public TicketLogService(LoggingDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
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
    }
}
