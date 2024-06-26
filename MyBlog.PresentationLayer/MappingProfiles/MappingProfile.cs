using AutoMapper;
using MyBlog.DataAccessLayer.Dto;
using MyBlog.PresentationLayer.Areas.Admin.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CategoryBlogCountChartDto, CategoryBlogCountChart>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
            .ForMember(dest => dest.BlogCount, opt => opt.MapFrom(src => src.BlogCount));
    }
}
