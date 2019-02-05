﻿using AutoMapper;
using Chat.Logic.Models;
using KvitkouNet.Messages.UserManagement;

namespace Chat.Web.MappingProfiles
{
    public class UserCreationProfile : Profile
    {
        public UserCreationProfile()
        {
            CreateMap<UserCreationMessage, User>()
                .ForMember(logic => logic.Id,
                    opt => opt.MapFrom(messages => messages.UserId))
                .ForMember(logic => logic.UserName,
                    opt => opt.MapFrom(messages => messages.FirstName)
                    );
        }
    }
}
