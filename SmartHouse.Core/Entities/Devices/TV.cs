using SmartHouse.Core.Entities.Rooms;

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
