using Microsoft.Extensions.DependencyInjection;
using Shop.Api.Core.Abstract;
using Shop.Api.Core.Services;
using Shop.Api.Data.Abstract;
using Shop.Api.Data.Providers;

namespace Shop.Api.Config
{
    public static class ContainerConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductDataProvider, ProductDataProvider>();

            return services;
        }
    }
}