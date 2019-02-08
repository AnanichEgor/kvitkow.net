using System.Threading.Tasks;
using AutoMapper;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.UserSettings;
using TicketManagement.Data.Context;
using TicketManagement.Data.DbModels;

namespace TicketManagement.Logic.Subscriber
{
    /// <summary>
    ///     Класс для получения сообщений о удалении пользователя из UserSettings
    /// </summary>
    public class UserDeleteMessageConsumerFromSettings : IConsumeAsync<DeleteUserProfileMessage>
    {
        private readonly IMapper _mapper;
        private readonly TicketContext _ticketContext;

        public UserDeleteMessageConsumerFromSettings(TicketContext ticketContext, IMapper mapper)
        {
            _ticketContext = ticketContext;
            _mapper = mapper;
        }

        public async Task ConsumeAsync(DeleteUserProfileMessage message)
        {
            var modelDb = _mapper.Map<UserInfo>(message);
            _ticketContext.UserInfos.Remove(modelDb);
            await _ticketContext.SaveChangesAsync();
        }
    }
}