using System;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Redis
{
    public class ContainerConfig
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        private readonly IServiceCollection _service;
        
        public ContainerConfig(IServiceCollection service)
        {
            _service = service;
            ServiceProvider = Builder().BuildServiceProvider();
        }
        
        public IServiceCollection Builder()
        {
            _service.AddSingleton<IConnection, Connection>();

            return _service;
        }
    }
}