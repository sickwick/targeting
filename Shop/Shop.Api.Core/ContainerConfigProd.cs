using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.Api.Core.Abstract;
using Shop.Api.Core.Services;
using Shop.Api.Data.Abstract;
using Shop.Api.Data.Providers;

namespace Shop.Api.Core
{
    public class ContainerConfigProd
    {
        private readonly IServiceCollection _service;
        public ContainerConfigProd(IServiceCollection service)
        {
            _service = service;
        }

        public IServiceCollection Builder()
        {
            _service.TryAdd(ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());

            _service.AddTransient<IProductService, ProductService>();
            _service.AddTransient<IProductDataProvider, ProductDataProvider>();

            return _service;
        }
    }
}