using SmartHouse.Core.Entities.Rooms;

namespace SmartHouse.Core.Entities.Devices
{
    public class Microwave : TunableDegreesDevice
    {
        public Microwave(int minDegrees = int.MinValue, int maxDegrees = int.MaxValue , Room room = null, string id = null) 
            : base(DeviceType.Microwave, minDegrees, maxDegrees, room, id)
        {
        }
    }
}
