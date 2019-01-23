using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Castle.Components.DictionaryAdapter;
using Security.Data.ContextModels;
using Security.Data.Models;

namespace Security.Data.MapperProfiles
{
    class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDb>()
                .ForMember(x => x.AccessFunctions, 
                    opt => opt.MapFrom(_ => _.AccessFunctions
                        .Select(l=>new AccessFunctionDb{
                            Id = l.AccessFunction.Id,
                            Name = l.AccessFunction.Name,
                            FeatureId = l.AccessFunction.FeatureId,
                            AccessRights = l.AccessFunction.AccessFunctionAccessRights.Select(k => new AccessRightDb
                            {
                                Name = k.AccessRight.Name,
                                Id = k.AccessRight.Id
                            } ).ToList()
                        })))
                .ForMember(x => x.AccessRights, 
                    opt => opt.MapFrom(_ => _.AccessRights.Where(l=>!l.IsDenied)
                        .Select(l=>new AccessRightDb
                        {
                            Id = l.AccessRight.Id,
                            Name = l.AccessRight.Name,
                        })))
                .ForMember(x => x.DeniedRights, 
                    opt => opt.MapFrom(_ => _.AccessRights.Where(l=>l.IsDenied)
                        .Select(l=>new AccessRightDb
                        {
                            Id = l.AccessRight.Id,
                            Name = l.AccessRight.Name,
                        })))
                .ReverseMap()
                .ForMember(x => x.AccessFunctions, opt => opt.Ignore())
                .ForMember(x => x.AccessRights, opt => opt.Ignore());
        }
    }
}
