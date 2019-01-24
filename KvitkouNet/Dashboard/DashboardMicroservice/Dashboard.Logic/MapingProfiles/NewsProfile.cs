using AutoMapper;
using Dashboard.Data.DbModels;
using Dashboard.Logic.Models;

<<<<<<< HEAD
namespace Dashboard.Logic.MappingProfiles
=======
namespace Dashboard.Logic.MppingProfiles
>>>>>>> DashboardMicroservice
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<News, NewsDb>().ReverseMap();
        }
    }
}
