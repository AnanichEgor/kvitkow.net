using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TicketManagement.Data.DbModels;
using TicketManagement.Logic.Models;

namespace TicketManagement.Logic.MappingProfiles
{
    public class AddressProfile: Profile
    {

        public AddressProfile()
        {
            CreateMap<Address, AddressDb>().ReverseMap();
        }
    }
}
