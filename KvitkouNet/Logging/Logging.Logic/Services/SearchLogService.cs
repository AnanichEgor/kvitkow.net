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
    public class SearchLogService : BaseService, ISearchLogService
    {
        public SearchLogService(LoggingDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public Task<IEnumerable<SearchQueryLogEntry>> GetLogsAsync(SearchQueryLogsFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task AddLogAsync(SearchQueryLogEntry entry)
        {
            var dbModel = Mapper.Map<SearchQueryLogEntryDbModel>(entry);

            Context.SearchQueryLogEntries.Add(dbModel);

            await Context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
