using AutoMapper;
using Logging.Data.DbModels;
using Logging.Logic.Models;

namespace Logging.Logic.MappingProfiles.DomainToDbReverse
{
	public class TicketDealLogDomainToDbProfile : Profile
	{
		public TicketDealLogDomainToDbProfile()
		{
			CreateMap<TicketDealLogEntry, TicketDealLogEntryDbModel>()
				.ReverseMap();
		}
	}
}