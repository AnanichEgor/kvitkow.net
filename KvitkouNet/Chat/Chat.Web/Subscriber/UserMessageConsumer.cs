using System.Threading.Tasks;
using AutoMapper;
using Chat.Logic.Models;
using Chat.Logic.Services;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.UserManagement;

namespace Chat.Web.Subscriber
{
    public class UserMessageConsumer : IConsumeAsync<UserCreationMessage>
    {
        private ChatService m_service;
        private readonly IMapper _mapper;

        public UserMessageConsumer(ChatService service, IMapper mapper)
        {
            m_service = service;
            _mapper = mapper;
        }

        [AutoSubscriberConsumer(SubscriptionId = "UserService.Created")]
        public Task ConsumeAsync(UserCreationMessage message)
        {
            var modelLogic = _mapper.Map<User>(message);

            m_service.AddUser(modelLogic);

            return Task.CompletedTask;
        }

        [AutoSubscriberConsumer(SubscriptionId = "UserService.Updated")]
        public Task ConsumeAsync(UserUpdatedMessage message)
        {
            var modelLogic = _mapper.Map<User>(message);

            m_service.EditUser(modelLogic);

            return Task.CompletedTask;
        }
    }
}