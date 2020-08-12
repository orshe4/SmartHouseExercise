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
    [Command(Description = "Set new channel to a device")]
    class SetChannelCommand : BaseCommand
    {
        [Argument(0)]
        [Required]
        public DeviceType DeviceType { get; }

        [Argument(1)]
        [Required]
        public int NewChannel { get; }

        [Option]
        public RoomTypeParameter RoomType { get; }

        public SetChannelCommand(ISmartHouseService smartHouseService) : base(smartHouseService)
        {
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {            
            if (RoomType != RoomTypeParameter.None)
            {
                RoomType roomType = (RoomType)Enum.Parse(typeof(RoomType), RoomType.ToString());
                await SmartHouseService.ChangeDeviceChannel(roomType, DeviceType, NewChannel);
            }
            else
            {
                await SmartHouseService.ChangeDeviceChannel(DeviceType, NewChannel);
            }
            
            return 1;
        }
    }
}

