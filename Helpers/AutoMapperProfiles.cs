using AutoMapper;
using System.Linq;
using TouristGuide.API.Dtos;
using TouristGuide.API.Models;

namespace TouristGuide.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityForListDto>().ForMember(dest => dest.PhotoUrl, opt =>
            {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain == true).Url);
            });
            CreateMap<City, CityForDetailDto>();
        }
    }
}
