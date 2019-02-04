using AutoMapper;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.UserManagement;
using System.Threading.Tasks;
using TicketManagement.Data.Context;
using TicketManagement.Data.DbModels;

namespace TicketManagement.Logic.Subscriber
{
    public class UserMessageConsumer : IConsumeAsync<UserUpdatedMessage>, IConsumeAsync<UserDeletedMessage>
    {
        private readonly TicketContext _ticketContext;
        private readonly IMapper _mapper;

        public UserMessageConsumer(TicketContext ticketContext, IMapper mapper)
        {
            _ticketContext = ticketContext;
            _mapper = mapper;
        }

        [AutoSubscriberConsumer(SubscriptionId = "UserServiceForTicket.Updated")]
        public async Task ConsumeAsync(UserUpdatedMessage message)
        {
            var modelDb = _mapper.Map<UserInfo>(message);
            _ticketContext.UserInfos.Update(modelDb);
            await _ticketContext.SaveChangesAsync();
        }

        [AutoSubscriberConsumer(SubscriptionId = "UserServiceForTicket.Deleted")]
        public async Task ConsumeAsync(UserDeletedMessage message)
        {
            var modelDb = _mapper.Map<UserInfo>(message);
            _ticketContext.UserInfos.Remove(modelDb);
            await _ticketContext.SaveChangesAsync();
        }
    }
}