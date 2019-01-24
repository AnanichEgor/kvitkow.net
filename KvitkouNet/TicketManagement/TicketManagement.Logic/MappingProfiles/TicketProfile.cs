using AutoMapper;
using TicketManagement.Data.DbModels;
using TicketManagement.Logic.Models;

namespace TicketManagement.Logic.MappingProfiles
{
    /// <summary>
    ///     Настройка маппинга для тикетов
    /// </summary>
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDb>().ReverseMap();
            CreateMap<TicketDb, TicketLite>().ReverseMap();
        }
    }
}