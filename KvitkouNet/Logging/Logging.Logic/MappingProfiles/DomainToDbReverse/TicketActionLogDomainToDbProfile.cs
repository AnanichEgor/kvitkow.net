using AutoMapper;
using Logging.Data.DbModels;
using Logging.Logic.Models;

namespace Logging.Logic.MappingProfiles.DomainToDbReverse
{
	public class TicketActionLogDomainToDbProfile : Profile
	{
		public TicketActionLogDomainToDbProfile()
		{
			CreateMap<TicketActionLogEntry, TicketActionLogEntryDbModel>()
				.ReverseMap();
		}
	}
}