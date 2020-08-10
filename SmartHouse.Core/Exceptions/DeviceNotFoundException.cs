using SmartHouse.Core.Entities.Devices;
using SmartHouse.Core.Entities.Rooms;
using System;

namespace SmartHouse.Core.Exceptions
{
    public class DeviceNotFoundException : Exception
    {
        public DeviceNotFoundException(string deviceId) : base($"No device found with id {deviceId}") { }
        public DeviceNotFoundException(RoomType roomType, DeviceType deviceType) : base($"No {deviceType} device found on {roomType}") { }
    }
}
