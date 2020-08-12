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
    [Command(Description = "Query the activity of a device")]
    class QueryActivityCommand : BaseCommand
    {
        [Argument(0)]
        [Required]
        public DeviceType DeviceType { get; }

        [Option]
        public RoomTypeParameter RoomType { get; }

        public QueryActivityCommand(ISmartHouseService smartHouseService) : base(smartHouseService)
        {
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            ActivityStatus activityStatus;
            if (RoomType != RoomTypeParameter.None)
            {
                RoomType roomType = (RoomType)Enum.Parse(typeof(RoomType), RoomType.ToString());
                activityStatus = await SmartHouseService.GetActivityStatus(roomType, DeviceType);
            }
            else
            {
                activityStatus = await SmartHouseService.GetActivityStatus(DeviceType);
            }
             
            Console.WriteLine(activityStatus.IsActive ? "Device is active" : "Inactive device");
            return 1;
        }
    }
}

