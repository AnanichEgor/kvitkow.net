using AutoMapper;
using TicketManagement.Data.DbModels;
using TicketManagement.Logic.Models;

namespace TicketManagement.Logic.MappingProfiles
{
    /// <summary>
    ///     Настройка маппинга для юзеров
    /// </summary>
    public class UserInfoProfile : Profile
    {
        public UserInfoProfile()
        {
            CreateMap<UserInfo, UserInfoDb>().ReverseMap();
        }
    }
}