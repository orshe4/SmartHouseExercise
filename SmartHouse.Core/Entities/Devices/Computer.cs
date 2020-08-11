using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Rooms;
using System.Collections.Generic;

namespace SmartHouse.Core.Entities.Devices
{
    public class Computer : Device
    {
        public Computer(List<CommandType> availableCommandTypes, DeviceType deviceType, Room room = null, string id = null) 
            : base(availableCommandTypes, DeviceType.Computer, room, id)
        {
        }
    }
}
