using AutoMapper;
using KvitkouNet.Messages.UserSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserSettings.Logic.Models;

namespace UserSettings.Web.MappingProfile
{
	public class UserProfile: Profile
	{
		public UserProfile()
		{
			CreateMap<UserProfileMessage, ProfileInfo>().ReverseMap();
		}
	}
}
