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
        }
    }
}