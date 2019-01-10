using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Logging.Data;
using Logging.Logic.Dtos;
using Logging.Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace Logging.Logic.Services
{
	public class LoggingService : ILoggingService
	{
		private readonly LoggingDbContext _context;
		private readonly IMapper _mapper;

		//TODO создать интерфейс контекста, если будет такая необходимость
		public LoggingService(LoggingDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public Task<IEnumerable<AccountLogEntry>> GetAccountLogsAsync(AccountLogsFilterDto filter)
		{
			throw new System.NotImplementedException();
		}

		public Task AddAccountLogAsync(AccountLogEntry entry)
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEnumerable<InternalErrorLogEntry>> GetErrorLogsAsync(ErrorLogsFilterDto filter)
		{
			return _mapper.Map<InternalErrorLogEntry[]>(await _context.InternalErrorLogEntries.AsNoTracking().ToArrayAsync());
		}

		public Task AddErrorLogAsync(InternalErrorLogEntry entry)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<TicketActionLogEntry>> GetTicketActionLogsAsync(TicketLogsFilterDto filter)
		{
			throw new System.NotImplementedException();
		}

		public Task AddTicketActionLogAsync(TicketActionLogEntry entry)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<TicketDealLogEntry>> GetTicketDealLogsAsync(TicketLogsFilterDto filter)
		{
			throw new System.NotImplementedException();
		}

		public Task AddTicketDealLogAsync(TicketDealLogEntry entry)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<PaymentLogEntry>> GetPaymentLogsAsync(PaymentLogsFilterDto filter)
		{
			throw new System.NotImplementedException();
		}

		public Task AddPaymentLogAsync(PaymentLogEntry entry)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<SearchQueryLogEntry>> GetSearchQueryLogsAsync(SearchQueryLogsFilterDto filter)
		{
			throw new System.NotImplementedException();
		}

		public Task AddSearchQueryLogAsync(SearchQueryLogEntry entry)
		{
			throw new System.NotImplementedException();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
