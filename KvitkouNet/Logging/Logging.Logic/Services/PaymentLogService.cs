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
    public class PaymentLogService : BaseService, IPaymentLogService
    {
        public PaymentLogService(LoggingDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
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
    }
}
