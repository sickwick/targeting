using Autofac;
using Microsoft.Extensions.Caching.Memory;
using Shop.Core.DataProviders;
using Shop.Core.Interfaces.DataProviders;
using Shop.Core.Interfaces.Services;
using Shop.Core.Services;

namespace Shop.Core
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