using AutoMapper;
using testAPI.DTOs;

namespace testAPI
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<CreateCategoryDto, Category>()
              .ForMember(destination => destination.Theme, opr => opr.MapFrom(src => src.ThemeName));
        
        
        }
    }
}
