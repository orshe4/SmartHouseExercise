using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Devices;
using SmartHouse.Core.Entities.Rooms;
using SmartHouse.Core.Interfaces;
using SmartHouse.Core.Services;
using SmartHouse.Infrastructure.Ioc;
using System;
using System.ComponentModel.DataAnnotations;

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

            var app = new CommandLineApplication<Program>();
            app.Conventions
                .UseDefaultConventions()
                .UseConstructorInjection(serviceProvider);
            return app.Execute(args);
        }

        private ISmartHouseService _smartHouseService;


        [Argument(0)]
        [Required]
        public CommandType Command { get; }

        [Argument(1)]
        [Required]
        public DeviceType DeviceType { get; }

        [Argument(2)]
        public RoomTypeParameter RoomType { get; }

        public string[] RemainingArguments { get; }

        public Program(ISmartHouseService smartHouseService)
        {
            _smartHouseService = smartHouseService;
        }


        /// <summary>
        /// Called by CommandLineApplication
        /// </summary>
        private void OnExecute()
        {
            switch (Command)
            {
                case CommandType.TurnOn:
                    if(RoomType == RoomTypeParameter.None)
                    {

                    }
                    else
                    {

                    }
                    break;
                case CommandType.TurnOff:
                    break;
                case CommandType.QueryActivityStatus:                
                    break;
                case CommandType.ChangeDegrees:
                    break;
                case CommandType.QueryDegrees:
                    break;
                case CommandType.QueryChannel:
                    break;
                case CommandType.ChangeChannel:
                    break;                
            }                
        }
    }
}
