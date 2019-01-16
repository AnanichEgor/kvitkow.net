using AutoMapper;
using TicketManagement.Data.DbModels;
using TicketManagement.Logic.Models;

namespace TicketManagement.Logic.MappingProfiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDb>().ReverseMap();
        }
    }
}