using AutoMapper;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.UserSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Logic.Services;

namespace UserManagement.Web.Subscriber
{
    public class UserSettingsConsumer :
        IConsumeAsync<EmailUpdateMessage>,
        IConsumeAsync<PasswordUpdateMessage>,
        IConsumeAsync<UserProfileMessage>,
        IConsumeAsync<DeleteUserProfileMessage>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserSettingsConsumer(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }
        public async Task ConsumeAsync(EmailUpdateMessage message)
        {
            await _userService.UpdateEmail(message);
        }

        public Task ConsumeAsync(PasswordUpdateMessage message)
        {
            throw new NotImplementedException();
        }

        public Task ConsumeAsync(UserProfileMessage message)
        {
            throw new NotImplementedException();
        }

        public Task ConsumeAsync(DeleteUserProfileMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
