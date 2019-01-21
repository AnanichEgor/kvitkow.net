using AutoMapper;
using UserSettings.Data.DbModels;
using UserSettings.Logic.Models;

namespace UserSettings.Logic.MappingProfile
{
	public class SettingsProfile: AutoMapper.Profile
	{
		public SettingsProfile()
		{
			CreateMap<Settings,SettingsDb>()
				.ForMember(c => c.UserId, dest => dest.MapFrom(x=>x.UserId))
				.ForMember(c => c.Profile,
				map => map.MapFrom(
					dest => new Models.Profile
					{
						FirstName = dest.Profile.FirstName,
						LastName = dest.Profile.LastName,
						PreferRegion = dest.Profile.PreferRegion,
						IsPrivateAccount = dest.Profile.IsPrivateAccount,
						IsGetTicketInfo = dest.Profile.IsGetTicketInfo
					}))
				.ForMember(c => c.Account, 
				map => map.MapFrom(
					dest => new Account
					{
						Email = dest.Account.Email,
						Password = dest.Account.Password
					}
					)).ReverseMap();
		}
	}
}
