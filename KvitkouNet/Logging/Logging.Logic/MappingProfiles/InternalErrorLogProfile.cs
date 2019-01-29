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
			    .ForMember(dbm => dbm.ExceptionType, opts => opts.MapFrom(m => m.TypeName))
				.ReverseMap()
			    .ForMember(m => m.TypeName, opts => opts.MapFrom(dbm => dbm.ExceptionType));
		}
	}
}