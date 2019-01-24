using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Security.Data.ContextModels;
using Security.Data.Models;

namespace Security.Data.MapperProfiles
{
    public class FeatureProfile : Profile
    {
        public FeatureProfile()
        {
            CreateMap<Feature, FeatureDb>()
                .ForMember(x => x.AvailableAccessRights, 
                    opt => opt.MapFrom(_ => _.FeatureAccessRight
                        .Select(l=>new AccessRightDb{
                            Id = l.AccessRight.Id,
                            Name = l.AccessRight.Name})))
                .ReverseMap()
                .ForMember(x => x.FeatureAccessRight, opt => opt.Ignore());
        }
    }
}
