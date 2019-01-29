using AutoMapper;
using Dashboard.Data.DbModels;
using Dashboard.Logic.Models;

namespace Dashboard.Logic.MappingProfiles
{
    public class UserInfoProfile : Profile
    {
        public UserInfoProfile()
        {
            CreateMap<UserInfo, UserInfoDb>().ReverseMap();
        }
    }
}
