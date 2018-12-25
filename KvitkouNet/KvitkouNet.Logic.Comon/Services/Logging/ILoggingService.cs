using System.Collections.Generic;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Dtos.Logging;
using KvitkouNet.Logic.Common.Models.Logging;

namespace KvitkouNet.Logic.Common.Services.Logging
{
	public interface ILoggingService
	{
		Task<IEnumerable<AccountLogEntry>> Get(AccountLogsFilterDto accountLogsFilter);
	}
}
