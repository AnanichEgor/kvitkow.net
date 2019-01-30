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
			    .ForMember(dbm => dbm.ExceptionType, opts => opts.MapFrom(m => m.ExceptionType))
				.ReverseMap()
			    .ForMember(m => m.ExceptionType, opts => opts.MapFrom(dbm => dbm.ExceptionType));
		}
	}
}