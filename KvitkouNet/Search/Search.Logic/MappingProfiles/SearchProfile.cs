using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Search.Data.Models;
using Search.Logic.Common.Models;

namespace Search.Logic.MappingProfiles
{
    public class SearchProfile : Profile
    {
        public SearchProfile()
        {
            CreateMap<SearchRequest, SearchEntity>()
                .ForMember(entity => entity.SearchTime,
                    opt => opt.MapFrom(request => DateTime.UtcNow));
            // todo   .ForMember(entity => entity.UserId);
        }
    }
}
