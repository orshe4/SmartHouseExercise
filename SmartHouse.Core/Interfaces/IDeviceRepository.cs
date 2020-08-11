using SmartHouse.Core.Entities.Devices;
using SmartHouse.Core.Entities.Rooms;
using System.Collections.Generic;

namespace SmartHouse.Core.Interfaces
{
    public interface IDeviceRepository
    {
        void AddDevice(Device device);
        IReadOnlyList<Device> GetDevices();      
        Device GetDevice(string deviceId);
        Device GetDevice(RoomType roomType, DeviceType deviceType);
        Device GetDevice(DeviceType deviceType);
    }
}
