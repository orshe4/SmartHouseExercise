using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Devices;
using System;

namespace SmartHouse.Core.Exceptions
{
    public class NotCompatibleCommandException : Exception
    {
        public NotCompatibleCommandException(DeviceCommand deviceCommand) : this(deviceCommand.Device, deviceCommand.Command)            
        { }

        public NotCompatibleCommandException(Device device, Command command) :
          base($"{device.DeviceType} is not compatible with command type {command.CommandType}")
        { }

        
    }
}
