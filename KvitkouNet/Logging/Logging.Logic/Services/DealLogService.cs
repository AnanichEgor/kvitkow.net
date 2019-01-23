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
    public class DealLogService : BaseService, IDealLogService
    {
        public DealLogService(LoggingDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
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
    }
}
