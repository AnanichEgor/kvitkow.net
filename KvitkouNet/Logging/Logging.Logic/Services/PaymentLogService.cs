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
    public class PaymentLogService : IPaymentLogService
    {
        protected readonly LoggingDbContext Context;
        protected readonly IMapper Mapper;

        public PaymentLogService(LoggingDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public Task<IEnumerable<PaymentLogEntry>> GetLogsAsync(PaymentLogsFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task AddLogAsync(PaymentLogEntry entry)
        {
            var dbModel = Mapper.Map<PaymentLogEntryDbModel>(entry);

            Context.PaymentLogEntries.Add(dbModel);

            await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
