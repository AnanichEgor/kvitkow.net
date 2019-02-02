using System.Threading.Tasks;
using AutoMapper;
using Chat.Logic.Models;
using Chat.Logic.Services;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.UserManagement;

namespace Chat.Web.Subscriber
{
    public class UserCreationMessageConsumer : IConsumeAsync<UserCreationMessage>
    {
        private ChatService m_service;
        private readonly IMapper _mapper;

        public UserCreationMessageConsumer(ChatService service, IMapper mapper)
        {
            m_service = service;
            _mapper = mapper;
        }

        [AutoSubscriberConsumer(SubscriptionId = "UserCreationMessage")]
        public Task ConsumeAsync(UserCreationMessage message)
        {
            var modelDb = _mapper.Map<User>(message);
            // implement business logic
            m_service.AddUser(modelDb);


            //Debug.WriteLine($"I've got message: {message.BookId} {message.UserId} ");
            return Task.CompletedTask;
        }
    }
}