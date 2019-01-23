using UserManagement.Data.DbModels;

namespace UserManagement.Logic.MappingProfiles
{
    public class ForViewModelProfile : AutoMapper.Profile
    {
        public ForViewModelProfile()
        {
            //CreateMap<Models.ForViewModel, UserDB>()
            //    .ForMember(x => x.AccountDB,
            //        opt => opt.Ignore())
            //    .ForMember(x => x.AccountDB.Login,
            //        opt => opt.MapFrom(_ => _.Login))
            //    .ForMember(x => x.ProfileDB.Birthday,
            //        opt => opt.MapFrom(_ => _.Birthday))
            //    .ForMember(x => x.ProfileDB.Rating,
            //        opt => opt.MapFrom(_ => _.Rating))
            //    .ForMember(x => x.ProfileDB.Sex,
            //        opt => opt.MapFrom(_ => _.Sex))
            //    .ForMember(x => x.ProfileDB.RegistrationDate,
            //        opt => opt.MapFrom(_ => _.RegistrationDate))
            //    .ReverseMap();
        }
    }
}
