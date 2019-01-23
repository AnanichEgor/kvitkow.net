using UserManagement.Data.DbModels;

namespace UserManagement.Logic.MappingProfiles
{
    public class AccountProfile : AutoMapper.Profile
    {
        public AccountProfile()
        {
            CreateMap<Models.UserRegisterModel, AccountDB>()
                .ForMember(x => x.Password,
                    opt => opt.MapFrom(_ => _.Password))
                .ReverseMap();
        }
    }
}
