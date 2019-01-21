using AutoMapper;
using UserSettings.Data.DbModels;
using UserSettings.Logic.Models;

namespace UserSettings.Logic.MappingProfile
{
	public class AccountProfile: AutoMapper.Profile
	{
		public AccountProfile()
		{
			CreateMap<Account, AccountDb>()
				.ForMember(source => source.Email, dest => dest.MapFrom(x=>x.Email))
				.ForMember(source => source.Password, dest => dest.MapFrom(x=>x.Password)).ReverseMap();
		}
	}
}
