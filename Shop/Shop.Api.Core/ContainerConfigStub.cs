using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.Api.Core.Abstract;
using Shop.Api.Core.Services;
using Shop.Api.Core.DataProviders;
using Shop.Database.Stubs;
using Shop.Storage.Interfaces.DataProviders;

namespace Shop.Api.Core
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