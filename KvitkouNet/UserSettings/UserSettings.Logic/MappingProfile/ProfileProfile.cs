using AutoMapper;
using UserSettings.Data.DbModels;

namespace UserSettings.Logic.MappingProfile
{
	public class ProfileProfile: Profile
	{
		public ProfileProfile()
		{
			CreateMap<Models.Profile, ProfileDb>()
				.ForMember(source => source.FirstName, dest => dest.MapFrom(x => x.FirstName))
				.ForMember(source => source.LastName, dest => dest.MapFrom(x => x.LastName))
				.ForMember(source => source.IsPrivateAccount, dest => dest.MapFrom(x=>x.IsPrivateAccount))
				.ForMember(source => source.PreferRegion, dest => dest.MapFrom(x=>x.PreferRegion))
				.ForMember(source => source.IsGetTicketInfo, dest => dest.MapFrom(x=>x.IsGetTicketInfo)).ReverseMap();
		}
	}
}
