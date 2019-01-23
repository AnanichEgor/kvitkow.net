using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Security.Data.ContextModels;
using Security.Data.Models;

namespace Security.Data.MapperProfiles
{
    class AccessFunctionProfile : Profile
    {
        public AccessFunctionProfile()
        {
            CreateMap<AccessFunction, AccessFunctionDb>()
                .ForMember(x => x.AccessRights, opt => opt.MapFrom(_ => _.AccessFunctionAccessRights
                    .Select(l => new AccessRightDb
                    {
                        Id = l.AccessRight.Id,
                        Name = l.AccessRight.Name
                    })))
                .ReverseMap()
                .ForMember(x => x.AccessFunctionAccessRights, opt => opt.Ignore());
        }
    }
}
