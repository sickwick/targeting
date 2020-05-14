using System;
using Autofac;
using Shop.Core.DataProviders;
using Shop.Core.Interfaces.DataProviders;
using Shop.Core.Services;
using Shop.WebAPI.Interfaces;

namespace Shop.Tests
{
    public static class ContainerTestConfig
    {
        private static Lazy<ILifetimeScope> _lazyContainer = new Lazy<ILifetimeScope>(BuildAutofacContainer);

        private static ILifetimeScope BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<IProductService>().As<ProductService>();
            builder.RegisterType<IProductDataProvider>().As<ProductDataProvider>();
            
            return builder.Build();
        }

        public static ILifetimeScope GetContainer()
        {
            return _lazyContainer.Value;
        }
        
    }
}