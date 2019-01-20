using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logging.Data;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;

namespace Logging.Logic.Services
{
    public class PaymentLogService : IPaymentLogService
    {
        protected readonly LoggingDbContext Context;

        public PaymentLogService(LoggingDbContext context)
        {
            Context = context;
        }

        public Task<IEnumerable<PaymentLogEntry>> GetLogsAsync(PaymentLogsFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task AddLogAsync(PaymentLogEntry entry)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
