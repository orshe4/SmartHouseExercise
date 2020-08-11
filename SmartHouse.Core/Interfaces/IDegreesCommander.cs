using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Devices;
using SmartHouse.Core.Entities.Rooms;
using System.Threading.Tasks;

namespace SmartHouse.Core.Interfaces
{
    public interface IDegreesCommander
    {
        Task ChangeDeviceDegrees(string deviceId, int newDegrees);
        Task ChangeDeviceDegrees(RoomType roomType, DeviceType deviceType, int newDegrees);
        Task<DegreesStatus> GetDegreesStatus(string deviceId);
        Task<DegreesStatus> GetDegreesStatus(RoomType roomType, DeviceType deviceType);
    }
}
