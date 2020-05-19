using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.Core.DataProviders;
using Shop.Core.Interfaces.DataProviders;
using Shop.Core.Interfaces.Services;
using Shop.Core.Services;

namespace Shop.Core
{
    public class ContainerConfig
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public ContainerConfig(IServiceCollection service)
        {
            service.TryAdd(ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());
            
            service.AddTransient<IProductService, ProductService>();
            service.AddTransient<IProductDataProvider, ProductDataProvider>();

            ServiceProvider = service.BuildServiceProvider();
        }
    }
}