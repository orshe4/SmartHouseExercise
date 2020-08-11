using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Rooms;
using System.Collections.Generic;

namespace SmartHouse.Core.Entities.Devices
{
    public class TV : ChannableDevice
    {
        public TV(List<CommandType> availableCommandTypes, Room room = null, string id = null) 
            : base(availableCommandTypes, DeviceType.TV, room, id)
        {
        }
    }
}
