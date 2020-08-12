using McMaster.Extensions.CommandLineUtils;
using SmartHouse.Core.Entities.Devices;
using SmartHouse.Core.Entities.Rooms;
using SmartHouse.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SmartHouse.CLI.Commands
{
    [Command(Description = "Turn on a device")]
    class TurnOnCommand : BaseCommand
    {

        [Argument(0)]
        [Required]
        public DeviceType DeviceType { get; }

        [Option]
        public RoomTypeParameter RoomType { get; }

        public TurnOnCommand(ISmartHouseService smartHouseService) : base(smartHouseService)
        {
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            if(RoomType != RoomTypeParameter.None)
            {
                RoomType roomType = (RoomType)Enum.Parse(typeof(RoomType), RoomType.ToString());
                await SmartHouseService.TurnOnDevice(roomType, DeviceType);
            }
            else
            {
                await SmartHouseService.TurnOnDevice(DeviceType);
            }
            return 1;
        }
    }
}
