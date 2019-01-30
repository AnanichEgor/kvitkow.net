using AutoMapper;
using UserSettings.Data.DbModels;
using UserSettings.Logic.Models;

namespace UserSettings.Logic.MappingProfile
{
	public class AccountProfile: AutoMapper.Profile
	{
		public AccountProfile()
		{
			CreateMap<Account, AccountDb>().ReverseMap();
		}
	}
}
