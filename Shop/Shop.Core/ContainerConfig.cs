using Microsoft.Extensions.DependencyInjection;
using Shop.Core.DataProviders;
using Shop.Core.Interfaces.DataProviders;
using Shop.Core.Interfaces.Services;
using Shop.Core.Services;

namespace Shop.Core
{
    public class ContainerConfig
    {
        public ContainerConfig(IServiceCollection provider)
        {
            provider.AddTransient<IProductService, ProductService>();
            provider.AddTransient<IProductDataProvider, ProductDataProvider>();
        }
    }
}