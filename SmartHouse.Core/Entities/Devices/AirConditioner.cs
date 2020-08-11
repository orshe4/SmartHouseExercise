using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Rooms;
using System.Collections.Generic;

namespace SmartHouse.Core.Entities.Devices
{
    public class AirConditioner : TunableDegreesDevice
    {
        public AirConditioner(List<CommandType> availableCommands, DeviceType deviceType, Room room = null, string id = null) 
            : base(availableCommands, DeviceType.AirConditioner, room, id)
        {
        }
    }
}
