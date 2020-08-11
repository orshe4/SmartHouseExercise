using Microsoft.Extensions.DependencyInjection;
using SmartHouse.Core.Interfaces;
using SmartHouse.Infrastructure.Data;

namespace SmartHouse.Infrastructure.Ioc
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            SimpleSmartHouseRepository simpleSmartHouseRepository = new SimpleSmartHouseRepository();
            services.AddSingleton<IDeviceRepository>(simpleSmartHouseRepository);
            services.AddSingleton<IRoomRepository>(simpleSmartHouseRepository);
            services.AddSingleton<ICommandSender, SimpleCommandSender>();
            return services;
        }
    }
}
