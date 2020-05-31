using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.Core.DataProviders;
using Shop.Core.Services;
using Shop.Storage.Interfaces.DataProviders;
using Shop.Storage.Interfaces.Services;

namespace Shop.Core
{
    public class ContainerConfig
    {
        public ContainerConfig(IServiceCollection service)
        {
            service.TryAdd(ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());

            service.AddTransient<IProductService, ProductService>();
            service.AddTransient<IProductDataProvider, ProductDataProvider>();

            ServiceProvider = service.BuildServiceProvider();
        }

        public static IServiceProvider ServiceProvider { get; private set; }
    }
}