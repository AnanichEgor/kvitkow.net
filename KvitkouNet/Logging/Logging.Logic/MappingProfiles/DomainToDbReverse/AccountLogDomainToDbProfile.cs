using AutoMapper;
using Logging.Data.DbModels;
using Logging.Logic.Models;

namespace Logging.Logic.MappingProfiles.DomainToDbReverse
{
	public class AccountLogDomainToDbProfile : Profile
	{
		public AccountLogDomainToDbProfile()
		{
			CreateMap<AccountLogEntry, AccountLogEntryDbModel>()
				.ReverseMap();
		}
	}
}