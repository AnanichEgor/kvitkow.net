using UserManagement.Data.DbModels;
using UserManagement.Logic.Models;

namespace UserManagement.Logic.MappingProfiles
{
    public class UserRegisterProfile : AutoMapper.Profile
    {
        public UserRegisterProfile()
        {
            CreateMap<UserRegisterModel, UserDB>()
                .ForMember(c => c.AccountDB,
                map => map.MapFrom(
                    a => new AccountDB
                    {
                        Login = a.Username,
                        Email = a.Email,
                        Password = a.Password
                    }))
                .ReverseMap();

        }
    }
}
