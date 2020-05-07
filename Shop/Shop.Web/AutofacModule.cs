using Autofac;
using Microsoft.Extensions.Caching.Memory;
using Shop.Database;
using Shop.Database.Interfaces;
using Shop.Web.Interfaces;
using Shop.Web.Services;

namespace Shop.Web
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