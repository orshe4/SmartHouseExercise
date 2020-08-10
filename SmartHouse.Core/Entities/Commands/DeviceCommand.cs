using SmartHouse.Core.Entities.Devices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHouse.Core.Entities.Commands
{
    public class DeviceCommand
    {
        public Command Command { get; }
        public Device Device { get; }

        public DeviceCommand(Command command, Device device)
        {
            Command = command;
            Device = device;
        }
    }
}
