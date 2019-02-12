using AutoMapper;
using KvitkouNet.Messages.UserManagement;
using KvitkouNet.Messages.UserSettings;
using TicketManagement.Data.DbModels;
using TicketManagement.Logic.Models;
using UserInfo = TicketManagement.Data.DbModels.UserInfo;

namespace TicketManagement.Logic.MappingProfiles
{
    /// <summary>
    ///     Настройка маппинга для юзеров
    /// </summary>
    public class UserInfoProfile : Profile
    {
        public UserInfoProfile()
        {
            CreateMap<Models.UserInfo, UserInfo>()
                .ReverseMap();
            CreateMap<UserDeletedMessage, UserInfo>()
                .ReverseMap()
                .ForPath(message => message.UserId,
                    expression => expression.MapFrom(info => info.UserInfoId));
            CreateMap<DeleteUserProfileMessage, UserInfo>()
                .ReverseMap()
                .ForPath(message => message.UserId,
                    expression => expression.MapFrom(info => info.UserInfoId));
            CreateMap<UserUpdatedMessage, UserInfo>()
                .ReverseMap()
                .ForPath(message => message.UserId,
                    expression => expression.MapFrom(info => info.UserInfoId));
            CreateMap<UserProfileUpdateMessage, UserInfo>()
                .ReverseMap()
                .ForPath(message => message.UserId,
                    expression => expression.MapFrom(info => info.UserInfoId));
        }
    }
}