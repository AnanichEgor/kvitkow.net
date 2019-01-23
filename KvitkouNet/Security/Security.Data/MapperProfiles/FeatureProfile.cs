using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Security.Data.ContextModels;
using Security.Data.Models;

namespace Security.Data.MapperProfiles
{
    class FeatureProfile : Profile
    {
        public FeatureProfile()
        {
            CreateMap<Feature, FeatureDb>()
                .ForMember(x => x.AvailableAccessRights, 
                    opt => opt.MapFrom(_ => _.AvailableAccessRights
                        .Select(l=>new AccessRightDb{
                            Id = l.AccessRight.Id,
                            Name = l.AccessRight.Name})))
                .ReverseMap()
                .ForMember(x => x.AvailableAccessRights, opt => opt.Ignore());
        }
    }
}
