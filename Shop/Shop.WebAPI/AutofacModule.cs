using Autofac;
using Microsoft.Extensions.Caching.Memory;
using Shop.Database;
using Shop.Database.Interfaces;
using Shop.WebAPI.Interfaces;
using Shop.WebAPI.Services;

namespace Shop.WebAPI
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MemoryCache>().As<IMemoryCache>().SingleInstance();
            
            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
            builder.RegisterType<ProductDataProvider>().As<IProductDataProvider>().SingleInstance();

        }
    }
}