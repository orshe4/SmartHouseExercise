using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Rooms;
using System.Collections.Generic;

namespace SmartHouse.Core.Entities.Devices
{
    public class TV : ChannableDevice
    {
        public TV(Room room = null, string id = null) 
            : base(DeviceType.TV, room, id)
        {
        }
    }
}
