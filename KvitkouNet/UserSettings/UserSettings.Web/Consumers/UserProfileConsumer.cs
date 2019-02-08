using AutoMapper;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.UserSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserSettings.Logic.Services;

namespace UserSettings.Web.Consumers
{
	public class UserProfileConsumer : IConsumeAsync<UserProfileMessage>
	{
		private readonly IMapper _mapper;
		private readonly IUserSettingsService _userSettingsService;

		public UserProfileConsumer(IMapper mapper, IUserSettingsService userSettingsService)
		{
			_mapper = mapper;
			_userSettingsService = userSettingsService;
		}
		public Task ConsumeAsync(UserProfileMessage message)
		{
			return null;//await _userSettingsService.Get();
		}
	}
}
