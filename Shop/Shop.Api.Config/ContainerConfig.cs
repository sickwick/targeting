using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.Api.Core.Abstract;
using Shop.Api.Core.Services;
using Shop.Api.Data.Abstract;
using Shop.Api.Data.Providers;

namespace Shop.Api.Config
{
    public class ContainerConfig
    {
        private readonly IServiceCollection _service;
        public ContainerConfig(IServiceCollection service)
        {
            _service = service;
            ServiceProvider = Builder().BuildServiceProvider();
        }
        public static IServiceProvider ServiceProvider { get; private set; }
        
        public IServiceCollection Builder()
        {
            _service.TryAdd(ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());

            _service.AddTransient<IProductService, ProductService>();
            _service.AddTransient<IProductDataProvider, ProductDataProvider>();

            return _service;
        }
    }
}