using SmartHouse.Core.Entities.Rooms;

namespace SmartHouse.Core.Entities.Devices
{
    public class Computer : Device
    {
        public Computer(Room room = null, string id = null) 
            : base(DeviceType.Computer, room, id)
        {
        }
    }
}
