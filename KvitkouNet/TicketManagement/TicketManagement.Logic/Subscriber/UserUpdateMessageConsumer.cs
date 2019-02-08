﻿using System;
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
  public  class UserUpdateMessageConsumer : IConsumeAsync<UserUpdatedMessage>
    {
        private TicketContext _ticketContext;
        private IMapper _mapper;

        public UserUpdateMessageConsumer(TicketContext ticketContext, IMapper mapper)
        {
            _ticketContext = ticketContext;
            _mapper = mapper;
        }
        
        public async Task ConsumeAsync(UserUpdatedMessage message)
        {
            var modelDb = _mapper.Map<UserInfo>(message);
            _ticketContext.UserInfos.Update(modelDb);
            await _ticketContext.SaveChangesAsync();
        }
    }
}
