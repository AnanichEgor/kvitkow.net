using AutoMapper;
using TicketManagement.Data.DbModels;
using TicketManagement.Logic.Models;
using Ticket = TicketManagement.Data.DbModels.Ticket;

namespace TicketManagement.Logic.MappingProfiles
{
    /// <summary>
    ///     Настройка маппинга для тикетов
    /// </summary>
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Models.Ticket, Ticket>().ReverseMap();
            CreateMap<Ticket, TicketLite>().ReverseMap();
        }
    }
}