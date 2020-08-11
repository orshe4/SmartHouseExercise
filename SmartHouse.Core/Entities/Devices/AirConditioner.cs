using SmartHouse.Core.Entities.Rooms;

namespace SmartHouse.Core.Entities.Devices
{
    public class AirConditioner : TunableDegreesDevice
    {
        public AirConditioner(int minDegrees = int.MinValue, int maxDegrees = int.MaxValue, Room room = null, string id = null) 
            : base(DeviceType.AirConditioner, minDegrees, maxDegrees, room, id)
        {
        }
    }
}
