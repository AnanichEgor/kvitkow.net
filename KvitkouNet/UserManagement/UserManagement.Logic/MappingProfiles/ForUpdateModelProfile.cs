
using UserManagement.Data.DbModels;
using UserManagement.Data.DbModels.Enums;
using UserManagement.Logic.Models;

namespace UserManagement.Logic.MappingProfiles
{
    public class ForUpdateModelProfile : AutoMapper.Profile
    {
        public ForUpdateModelProfile()
        {
            CreateMap<ForUpdateModel, UserDB>()
                .ForPath(x => x.ProfileDB.FirstName,
                    map => map.MapFrom(u => u.FirstName))
                .ForPath(x => x.ProfileDB.LastName,
                    map => map.MapFrom(u => u.LastName))
                .ForPath(x => x.ProfileDB.Sex,
                    map => map.MapFrom(u => u.Sex))
                .ForPath(x => x.ProfileDB.Birthday,
                    map => map.MapFrom(u => u.Birthday))
                .ReverseMap()
                .ForPath(y => y.FirstName,
                    map => map.MapFrom(u => u.ProfileDB.FirstName))
                .ForPath(y => y.LastName,
                    map => map.MapFrom(u => u.ProfileDB.LastName))
                .ForPath(y => y.Sex,
                    map => map.MapFrom(u => u.ProfileDB.Sex))
                .ForPath(y => y.Birthday,
                    map => map.MapFrom(u => u.ProfileDB.Birthday));
        }
    }
}
