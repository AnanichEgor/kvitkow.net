using AutoMapper;
using Security.Data.Models;
using Security.Logic.Models;

namespace Security.Logic.MappingProfiles
{
    public class FetureProfile : Profile
    {
        public FetureProfile()
        {
            CreateMap<Feature, FeatureDb>().ReverseMap();
        }
    }
}
