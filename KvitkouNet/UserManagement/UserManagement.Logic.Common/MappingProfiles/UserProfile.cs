using UserManagement.Data.DbModels;
using UserManagement.Logic.Models;

namespace UserManagement.Logic.MappingProfiles
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDB>()
                .ForMember(x => x.AccountDB,
                    opt => opt.MapFrom(_ => _.Account))
                .ForMember(x => x.ProfileDB,
                    opt => opt.MapFrom(_ => _.Profile))
                .ReverseMap();
        }
    }
}
