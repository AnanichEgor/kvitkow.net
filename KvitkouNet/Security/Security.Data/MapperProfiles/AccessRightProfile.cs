using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Security.Data.ContextModels;
using Security.Data.Models;

namespace Security.Data.MapperProfiles
{
    public class AccessRightProfile : Profile
    {
        public AccessRightProfile()
        {
            CreateMap<string, AccessRight>()
                .ForMember(x => x.Name,
                    opt => opt.MapFrom(_ => _));
        }
    }
}
