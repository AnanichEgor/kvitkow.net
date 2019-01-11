using AutoMapper;
using UserSettings.Data.DbModels;

namespace UserSettings.Logic.MappingProfile
{
	public class AccountProfile: Profile
	{
		public AccountProfile()
		{
			CreateMap<AccountProfile, AccountDb>().ReverseMap();
		}
	}
}
