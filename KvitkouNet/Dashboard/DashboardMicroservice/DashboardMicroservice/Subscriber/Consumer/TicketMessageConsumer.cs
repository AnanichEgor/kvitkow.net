﻿/*using System.Threading.Tasks;
using AutoMapper;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.TicketManagement;
using Dashboard.Data.Repositories;
using Dashboard.Logic.Models;

namespace Dashboard.Subscriber.Cunsumer
{
    public class TicketMessageConsumer : IConsumeAsync<TicketCreationMessage>,IConsumeAsync<TicketUpdatedMessage> IConsumeAsync<TicketDeletedMessage>
    {
        private readonly IDashboardRepository _NewsRepository;
        private readonly IMapper _mapper;

        public TicketMessageConsumer(IDashboardRepository ticketRepository, IMapper mapper)
        {
            _NewsRepository = ticketRepository;
            _mapper = mapper;
        }

        [AutoSubscriberConsumer(SubscriptionId = "TicketService.Created")]
        public async Task ConsumeAsync(TicketCreationMessage message)
        {
            await _NewsRepository.Add(_mapper.Map<News>(message));
        }
        
        [AutoSubscriberConsumer(SubscriptionId = "TicketService.Updated")]
        public async Task ConsumeAsync(TicketUpdatedMessage message)
        {
            await _NewsRepository.SaveAsync(_mapper.Map<TicketInfo>(message));
        }

        [AutoSubscriberConsumer(SubscriptionId = "TicketService.Deleted")]
        public async Task ConsumeAsync(TicketDeletedMessage message)
        {
            await _NewsRepository.Delete(message.TicketId);
        }
    }
}*/

