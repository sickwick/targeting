using System.Xml.Serialization;
using AutoMapper;
using Shop.Api.Core.Models;
using Shop.Api.Data.Models;

namespace Shop.Api.Core.Services
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<Product, ProductDto>();
            // CreateMap<ProductDto, Product>()
            //     .ForMember(dest => dest.About, opt => opt.MapFrom(src => src.About))
            //     .ForMember(dest => dest.Article, opt => opt.MapFrom(src => src.Article))
            //     .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            //     .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            //     .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Label))
            //     .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo))
            //     .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            //     .ForMember(dest => dest.Season, opt => opt.MapFrom(src => src.Season))
            //     .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            //     .ForMember(dest => dest.SizesAvailable, opt => opt.MapFrom(src => src.SizesAvailable));
            //
            // CreateMap<Product, ProductDto>()
            //     .ForMember(dest => dest.About, opt => opt.MapFrom(src => src.About))
            //     .ForMember(dest => dest.Article, opt => opt.MapFrom(src => src.Article))
            //     .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            //     .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            //     .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Label))
            //     .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo))
            //     .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            //     .ForMember(dest => dest.Season, opt => opt.MapFrom(src => src.Season))
            //     .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            //     .ForMember(dest => dest.SizesAvailable, opt => opt.MapFrom(src => src.SizesAvailable))
            //     .ForMember(dest=>dest.Id, opt=>opt.Ignore());
        }
    }
}