using McMaster.Extensions.CommandLineUtils;
using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Devices;
using SmartHouse.Core.Entities.Rooms;
using SmartHouse.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SmartHouse.CLI.Commands
{
    [Command(Description = "Query the degrees of a device")]
    class QueryDegreesCommand : BaseCommand
    {
        [Argument(0)]
        [Required]
        public DeviceType DeviceType { get; }

        [Option]
        public RoomTypeParameter RoomType { get; }

        public QueryDegreesCommand(ISmartHouseService smartHouseService) : base(smartHouseService)
        {
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            DegreesStatus degreesStatus;
            if (RoomType != RoomTypeParameter.None)
            {
                RoomType roomType = (RoomType)Enum.Parse(typeof(RoomType), RoomType.ToString());
                degreesStatus = await SmartHouseService.GetDegreesStatus(roomType, DeviceType);
            }
            else
            {
                degreesStatus = await SmartHouseService.GetDegreesStatus(DeviceType);
            }

            Console.WriteLine($"Device degrees are {degreesStatus.Degrees}");
            return 1;
        }
    }
}

