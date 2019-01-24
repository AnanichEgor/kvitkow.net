using UserManagement.Data.DbModels;
using UserManagement.Logic.Models;

namespace UserManagement.Logic.MappingProfiles
{
    public class AccountProfile : AutoMapper.Profile
    {
        public AccountProfile()
        {
            CreateMap<UserRegisterModel, AccountDB>()
                .ForMember(x => x.Login,
                    opt => opt.MapFrom(_ => _.Username))
                .ForMember(x => x.Email,
                    opt => opt.MapFrom(_ => _.Email))
                .ForMember(x => x.Password,
                    opt => opt.MapFrom(_ => _.Password))
                //.ForMember(x => x.Password,
                //    opt => opt.MapFrom(_ => _.ConfirmPassword))
                .ReverseMap();


            //.ForMember(c => c.AccountDB,
            //    map => map.MapFrom(
            //        a => new AccountDB
            //        {
            //             Login = a.Login
            //        }))
            //.ForMember(c => c.ProfileDB,
            //    map => map.MapFrom(
            //        p => new ProfileDB
            //        {
            //            FirstName = p.FirstName,
            //            LastName = p.LastName,
            //            Sex = (SexDB)p.Sex,
            //            Birthday = p.Birthday,
            //            Rating = p.Rating,
            //            RegistrationDate = p.RegistrationDate
            //        }))
        }
    }
}
