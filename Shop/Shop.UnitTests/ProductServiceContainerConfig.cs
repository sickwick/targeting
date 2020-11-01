using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.Api.Core.Services;
using Shop.Database.Stubs;
using Shop.Storage.Interfaces.DataProviders;
using Shop.Storage.Interfaces.Services;

namespace Shop.UnitTests
{
    internal class ProductServiceContainerConfig
    {
        static ProductServiceContainerConfig()
        {
            if (_lazyContainer == null)
            {
                _lazyContainer = new Lazy<IServiceProvider>();
            }
        }


        private static readonly Lazy<IServiceProvider> _lazyContainer =
            new Lazy<IServiceProvider>(BuildContainer);

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