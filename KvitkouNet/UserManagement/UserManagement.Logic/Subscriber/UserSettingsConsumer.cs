using AutoMapper;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.TicketManagement;
using KvitkouNet.Messages.UserManagement;
using KvitkouNet.Messages.UserSettings;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using UserManagement.Logic.Services;

namespace UserManagement.Logic.Subscriber
{
    public class UserSettingsMessageConsumer :
        IConsumeAsync<EmailUpdateMessage>,
        IConsumeAsync<PasswordUpdateMessage>,
        IConsumeAsync<UserProfileMessage>,
        IConsumeAsync<DeleteUserProfileMessage>,
        IConsumeAsync<AccountMessage>,
        IConsumeAsync<TicketCreationMessage>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserSettingsMessageConsumer(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [AutoSubscriberConsumer(SubscriptionId = "UserSettingsService.EmailUpdated")]
        public async Task ConsumeAsync(EmailUpdateMessage message)
        {
            await _userService.UpdateEmail(message);
        }

        [AutoSubscriberConsumer(SubscriptionId = "UserSettingsService.PasswordUpdated")]
        public Task ConsumeAsync(PasswordUpdateMessage message)
        {
            throw new NotImplementedException();
        }

        [AutoSubscriberConsumer(SubscriptionId = "UserSettingsService.UserProfileUpdated")]
        public Task ConsumeAsync(UserProfileMessage message)
        {
            throw new NotImplementedException();
        }

        [AutoSubscriberConsumer(SubscriptionId = "UserSettingsService.UserProfileDeleted")]
        public Task ConsumeAsync(DeleteUserProfileMessage message)
        {
            throw new NotImplementedException();
        }

        [AutoSubscriberConsumer(SubscriptionId = "UserService.AccountCreated")]
        public async Task ConsumeAsync(AccountMessage message)
        {
            Debug.WriteLine($"I've got message: {message.UserName} {message.Email} ");
            EmailUpdateMessage eum = new EmailUpdateMessage();
            eum.Id = "2";//message.UserId;
            eum.Email = "1234@123.by";//message.Email;

            await _userService.UpdateEmail(eum);
            
        }

        [AutoSubscriberConsumer(SubscriptionId = "Tickets.TicketCreated")]
        public async Task ConsumeAsync(TicketCreationMessage message)
        {
            Debug.WriteLine($"I've got message: {message.Name} {message.Price} ");
            EmailUpdateMessage eum = new EmailUpdateMessage();
            eum.Id = "1";
            eum.Email = "77777777@123.by";
            await _userService.UpdateEmail(eum);
        }
    }
}
