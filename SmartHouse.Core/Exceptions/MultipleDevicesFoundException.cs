using SmartHouse.Core.Entities.Devices;
using SmartHouse.Core.Entities.Rooms;
using System;

namespace SmartHouse.Core.Exceptions
{
    public class MultipleDevicesFoundException : Exception
    {
        public MultipleDevicesFoundException(DeviceType deviceType): 
            base($"Multiple devices found for {deviceType}") { }

        public MultipleDevicesFoundException(RoomType roomType, DeviceType deviceType) :
            base($"Multiple devices found for room type {roomType} and {deviceType} device") { }        
    }
}
