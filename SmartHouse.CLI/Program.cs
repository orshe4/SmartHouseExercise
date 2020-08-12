using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using SmartHouse.Core.Interfaces;
using SmartHouse.Core.Services;
using SmartHouse.Infrastructure.Ioc;
using System;

namespace SmartHouse.CLI
{
    class Program
    {
        static int Main(string[] args)
        {
            IServiceProvider serviceProvider = new ServiceCollection()                
                .AddSingleton<ISmartHouseService, SmartHouseService>()
                .RegisterInfrastructureServices()
                .BuildServiceProvider();

            var app = new CommandLineApplication<SmartHouse>();
            app.Conventions
                .UseDefaultConventions()
                .UseConstructorInjection(serviceProvider);
            return app.Execute(args);
        }
    }
}
