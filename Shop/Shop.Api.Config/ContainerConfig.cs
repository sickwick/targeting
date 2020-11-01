using System;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Api.Config
{
    public class ContainerConfig
    {
        public ContainerConfig(IServiceCollection service, IWebHostEnvironment environment)
        {
            if (environment.IsProduction())
            {
                ServiceProvider = new ContainerConfigProd(service).Builder().BuildServiceProvider();
            }
            else
            {
                ServiceProvider = new ContainerConfigStub(service).Builder().BuildServiceProvider();
            }
        }
        public static IServiceProvider ServiceProvider { get; private set; }
    }
}