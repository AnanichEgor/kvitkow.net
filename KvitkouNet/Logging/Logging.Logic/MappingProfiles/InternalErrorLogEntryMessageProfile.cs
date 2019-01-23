using AutoMapper;
using KvitkouNet.Logic.Common.Messages.Logging;
using Logging.Logic.Models;

namespace Logging.Logic.MappingProfiles
{
	public class InternalErrorLogEntryMessageProfile : Profile
	{
		public InternalErrorLogEntryMessageProfile()
		{
			CreateMap<InternalErrorLogEntryMessage, InternalErrorLogEntry>()
				.ReverseMap();
		}
		
	}
}