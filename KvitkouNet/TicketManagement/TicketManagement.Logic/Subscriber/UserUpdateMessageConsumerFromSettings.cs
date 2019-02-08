using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.UserManagement;
using KvitkouNet.Messages.UserSettings;
using TicketManagement.Data.Context;
using TicketManagement.Data.DbModels;

namespace TicketManagement.Logic.Subscriber
{
  public  class UserUpdateMessageConsumerFromSettings: IConsumeAsync<UserProfileUpdateMessage>
    {
        private readonly TicketContext _ticketContext;
        private readonly IMapper _mapper;

        public UserUpdateMessageConsumerFromSettings(TicketContext ticketContext, IMapper mapper)
        {
            _ticketContext = ticketContext;
            _mapper = mapper;
        }
        
        public async Task ConsumeAsync(UserProfileUpdateMessage message)
        {
            var modelDb = _mapper.Map<UserInfo>(message);
            _ticketContext.UserInfos.Remove(modelDb);
            await _ticketContext.SaveChangesAsync();
        }
    }
}
