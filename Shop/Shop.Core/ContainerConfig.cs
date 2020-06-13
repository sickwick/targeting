using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Shop.Core
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