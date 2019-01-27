using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TicketManagement.Data.DbModels;
using TicketManagement.Logic.Models;
using Ticket = TicketManagement.Data.DbModels.Ticket;

namespace TicketManagement.Logic.MappingProfiles
{
    /// <summary>
    ///  Настройка маппинга для страниц тикетов
    /// </summary>
    public class PageTicketsProfile:Profile
    {
        public PageTicketsProfile()
        {
            CreateMap<Data.DbModels.Page<Ticket>, Models.Page<TicketLite>>().ReverseMap();
        }
    }
}
