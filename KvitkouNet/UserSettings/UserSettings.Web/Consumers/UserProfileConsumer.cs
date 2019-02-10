using AutoMapper;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.UserManagement;
using KvitkouNet.Messages.UserSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserSettings.Logic.Services;
using UserSettings.Web.MappingProfile;

namespace UserSettings.Web.Consumers
{
	public class UserProfileConsumer : IConsumeAsync<UserCreationMessage>
	{
		private readonly IMapper _mapper;
		private readonly IUserSettingsService _userSettingsService;

		public UserProfileConsumer(IMapper mapper, IUserSettingsService userSettingsService)
		{
			_mapper = mapper;
			_userSettingsService = userSettingsService;
		}
		public Task ConsumeAsync(UserCreationMessage message)
		{
			_userSettingsService.CreateSetting(message.UserId);
			return null;
		}
	}
}
