using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.Api.Core.Abstract;
using Shop.Api.Core.Services;
using Shop.Api.Data.Abstract;
using Shop.Api.Data.Providers;

namespace Shop.UnitTests
{
    public class ContainerTestConfig
    {
        private static readonly Lazy<IServiceProvider> _lazyContainer = new Lazy<IServiceProvider>(BuildContainer);

        public static IServiceProvider ServiceProvider { get; private set; }

        private static IServiceProvider BuildContainer()
        {
            var builder = new ServiceCollection();
            builder.AddMemoryCache();
            builder.AddTransient<IProductService, ProductService>();
            builder.AddTransient<IProductDataProvider, ProductDataProvider>();
            builder.TryAdd(ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());
            // builder.RegisterType<ServiceProvider>().As<IServiceProvider>().ExternallyOwned();
            // builder.Register(m=>new MemoryCache(new MemoryCacheOptions())).As<IMemoryCache>().ExternallyOwned();
            // builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
            // builder.RegisterType<ProductDataProvider>().As<IProductDataProvider>().SingleInstance();

            return builder.BuildServiceProvider();
        }

        public static IServiceProvider GetContainer()
        {
            // _serviceProvider = BuildAutofacContainer();
            return _lazyContainer.Value;
        }
    }
}