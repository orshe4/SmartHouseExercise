using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Devices;
using SmartHouse.Core.Entities.Rooms;
using System.Threading.Tasks;

namespace SmartHouse.Core.Interfaces
{
    public interface IActivityCommander
    {
        Task TurnOffDevice(string deviceId);
        Task TurnOffDevice(RoomType roomType, DeviceType deviceType);
        Task TurnOnDevice(string deviceId);
        Task TurnOnDevice(RoomType roomType, DeviceType deviceType);
        Task<ActivityStatus> GetActivityStatus(string deviceId);
        Task<ActivityStatus> GetActivityStatus(RoomType roomType, DeviceType deviceType);
    }
}
