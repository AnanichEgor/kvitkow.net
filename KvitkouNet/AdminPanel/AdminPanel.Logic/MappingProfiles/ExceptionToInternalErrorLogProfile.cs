using System;
using AdminPanel.Logic.Generated.Logging.Models;
using Profile = AutoMapper.Profile;

namespace AdminPanel.Logic.MappingProfiles
{
	public class ExceptionToInternalErrorLogProfile : Profile
	{
		public ExceptionToInternalErrorLogProfile()
		{
			CreateMap<Exception, InternalErrorLogEntry>();
		}
	}
}