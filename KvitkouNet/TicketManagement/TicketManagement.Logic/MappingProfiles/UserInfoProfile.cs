using AutoMapper;
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
            CreateMap<Models.UserInfo, UserInfo>().ReverseMap();
        }
    }
}