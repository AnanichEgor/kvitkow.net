using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TicketManagement.Data.DbModels;
using TicketManagement.Logic.Models;

namespace TicketManagement.Logic.MappingProfiles
{
    /// <summary>
    ///  Настройка маппинга для страниц тикетов
    /// </summary>
    public class PageTicketsProfile:Profile
    {
        public PageTicketsProfile()
        {
            CreateMap<Data.DbModels.Page<TicketDb>, Models.Page<TicketLite>>().ReverseMap();
        }
    }
}
