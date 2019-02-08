using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.UserManagement;
using TicketManagement.Data.Context;
using TicketManagement.Data.DbModels;

namespace TicketManagement.Logic.Subscriber
{
   public class UserDeleteMessageConsumer:IConsumeAsync<UserDeletedMessage>
    {
        private readonly TicketContext _ticketContext;
        private readonly IMapper _mapper;

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
