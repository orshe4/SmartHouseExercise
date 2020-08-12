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
    [Command(Description = "Set new degrees to a device")]
    class SetDegreesCommand : BaseCommand
    {
        [Argument(0)]
        [Required]
        public DeviceType DeviceType { get; }

        [Argument(1)]
        [Required]
        public int NewDegrees { get; }

        [Option]
        public RoomTypeParameter RoomType { get; }

        public SetDegreesCommand(ISmartHouseService smartHouseService) : base(smartHouseService)
        {
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            if (RoomType != RoomTypeParameter.None)
            {
                RoomType roomType = (RoomType)Enum.Parse(typeof(RoomType), RoomType.ToString());
                await SmartHouseService.ChangeDeviceDegrees(roomType, DeviceType, NewDegrees);
            }
            else
            {
                await SmartHouseService.ChangeDeviceDegrees(DeviceType, NewDegrees);
            }

            return 1;
        }
    }
}

