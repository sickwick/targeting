using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.Core.Services;
using Shop.Storage.Interfaces.DataProviders;
using Shop.Storage.Interfaces.Services;
using Shop.Tests.Stubs;

namespace Shop.Tests
{
    public static class ProductServiceContainerConfig
    {
        private static readonly Lazy<IServiceProvider> _lazyContainer = new Lazy<IServiceProvider>(BuildContainer);

        private static IServiceProvider BuildContainer()
        {
            var builder = new ServiceCollection();
            builder.AddMemoryCache();
            builder.AddTransient<IProductService, ProductService>();
            builder.AddTransient<IProductDataProvider, ProductDataProviderStub>();
            builder.TryAdd(ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());

            return builder.BuildServiceProvider();
        }

        public static IServiceProvider GetContainer()
        {
            return _lazyContainer.Value;
        }
    }
}