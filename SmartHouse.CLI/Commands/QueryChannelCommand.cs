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
    [Command(Description = "Query the channel of a device")]
    class QueryChannelCommand : BaseCommand
    {
        [Argument(0)]
        [Required]
        public DeviceType DeviceType { get; }

        [Option]
        public RoomTypeParameter RoomType { get; }

        public QueryChannelCommand(ISmartHouseService smartHouseService) : base(smartHouseService)
        {
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            ChannelStatus channelStatus;
            if (RoomType != RoomTypeParameter.None)
            {
                RoomType roomType = (RoomType)Enum.Parse(typeof(RoomType), RoomType.ToString());
                channelStatus = await SmartHouseService.GetChannelStatus(roomType, DeviceType);
            }
            else
            {
                channelStatus = await SmartHouseService.GetChannelStatus(DeviceType);
            }

            Console.WriteLine($"Device channel is {channelStatus.Channel}");
            return 1;
        }
    }
}

