using System;
using Autofac;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Shop.Core;
using Shop.Core.DataProviders;
using Shop.Core.Interfaces.DataProviders;
using Shop.Core.Interfaces.Services;
using Shop.Core.Services;

namespace Shop.Tests
{
    public static class ContainerTestConfig
    {
        private static Lazy<ILifetimeScope> _lazyContainer = new Lazy<ILifetimeScope>(BuildAutofacContainer);

        public static ILifetimeScope BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ServiceProvider>().As<IServiceProvider>().ExternallyOwned();
            builder.Register(m=>new MemoryCache(new MemoryCacheOptions())).As<IMemoryCache>().ExternallyOwned();
            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
            builder.RegisterType<ProductDataProvider>().As<IProductDataProvider>().SingleInstance();

            return builder.Build();
        }

        public static ILifetimeScope GetContainer()
        {
            return _lazyContainer.Value;
        }
        
    }
}