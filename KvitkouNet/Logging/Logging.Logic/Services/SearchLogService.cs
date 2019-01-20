using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logging.Data;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;

namespace Logging.Logic.Services
{
    public class SearchLogService : ISearchLogService
    {
        protected readonly LoggingDbContext Context;

        public SearchLogService(LoggingDbContext context)
        {
            Context = context;
        }

        public Task<IEnumerable<SearchQueryLogEntry>> GetLogsAsync(SearchQueryLogsFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task AddLogAsync(SearchQueryLogEntry entry)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
