using AutoMapper;
using UserSettings.Data.DbModels;

namespace UserSettings.Logic.MappingProfile
{
	public class ProfileProfile: Profile
	{
		public ProfileProfile()
		{
			CreateMap<ProfileProfile, ProfileDb>().ReverseMap();
		}
	}
}
