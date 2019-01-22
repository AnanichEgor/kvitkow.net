using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Security.Data.ContextModels;
using Security.Data.Models;

namespace Security.Data.MapperProfiles
{
    class AccessRightProfile : Profile
    {
        public AccessRightProfile()
        {
            CreateMap<AccessRight, AccessRightDb>()
                .ReverseMap();
        }
    }
}
