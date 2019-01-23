using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Data.DbModels;
using UserManagement.Logic.Models;

namespace UserManagement.Logic.MappingProfiles
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            //CreateMap<User, UserDB>()
            //    .ForMember(x => x.Account.UserId,
            //        opt => opt.MapFrom(_ => _.Account))
            //    .ReverseMap();
        }
    }
}
