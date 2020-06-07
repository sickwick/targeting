using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;


namespace Shop.Core
{
    public class ContainerConfig
    {
        public ContainerConfig(IServiceCollection service)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                ServiceProvider = new ContainerConfigStub(service).Builder().BuildServiceProvider();
            }
            else
            {
                ServiceProvider = new ContainerConfigProd(service).Builder().BuildServiceProvider();
            }
        }
        public static IServiceProvider ServiceProvider { get; private set; }
    }
}