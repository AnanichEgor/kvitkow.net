using AutoMapper;
using Logging.Data.DbModels;
using Logging.Logic.Models;

namespace Logging.Logic.MappingProfiles
{
	public class InternalErrorLogProfile : Profile
	{
		public InternalErrorLogProfile()
		{
			CreateMap<InternalErrorLogEntry, InternalErrorLogEntryDbModel>()
				.ReverseMap();
		}
	}
}