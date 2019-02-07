using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UserSettings.Data.DbModels;
using UserSettings.Logic.Models;

namespace UserSettings.Logic.MappingProfile
{
	public class NotificationsProfile: AutoMapper.Profile
	{
		public NotificationsProfile()
		{
			CreateMap<NotificationDb, Notifications>().ReverseMap();
		}
	}
}
