using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.Api.Core.DataProviders;
using Shop.Api.Core.Services;
using Shop.Storage.Interfaces.DataProviders;
using Shop.Storage.Interfaces.Services;

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