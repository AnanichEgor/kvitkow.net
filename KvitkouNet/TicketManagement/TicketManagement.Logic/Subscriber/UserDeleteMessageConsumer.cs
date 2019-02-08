using System.Threading.Tasks;
using AutoMapper;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.UserManagement;
using TicketManagement.Data.Context;
using TicketManagement.Data.DbModels;

namespace TicketManagement.Logic.Subscriber
{
    /// <summary>
    ///     Класс для получения сообщений о удалении пользователя из UserManager
    /// </summary>
    public class UserDeleteMessageConsumer : IConsumeAsync<UserDeletedMessage>
    {
        private readonly IMapper _mapper;
        private readonly TicketContext _ticketContext;

        public UserDeleteMessageConsumer(TicketContext ticketContext, IMapper mapper)
        {
            _ticketContext = ticketContext;
            _mapper = mapper;
        }

        public async Task ConsumeAsync(UserDeletedMessage message)
        {
            var modelDb = _mapper.Map<UserInfo>(message);
            _ticketContext.UserInfos.Remove(modelDb);
            await _ticketContext.SaveChangesAsync();
        }
    }
}