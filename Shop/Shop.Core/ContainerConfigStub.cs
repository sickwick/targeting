using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.Core.DataProviders;
using Shop.Core.Services;
using Shop.Database.Stubs;
using Shop.Storage.Interfaces.DataProviders;
using Shop.Storage.Interfaces.Services;

namespace Shop.Core
{
    public class ContainerConfigStub
    {
        private readonly IServiceCollection _service;
        public ContainerConfigStub(IServiceCollection service)
        {
            _service = service;
        }

        public IServiceCollection Builder()
        {
            _service.TryAdd(ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());

            _service.AddTransient<IProductService, ProductService>();
            _service.AddTransient<IProductDataProvider, ProductDataProviderStub>();

            return _service;
        }
    }
}