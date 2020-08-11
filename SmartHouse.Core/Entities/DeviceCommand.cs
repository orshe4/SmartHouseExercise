using SmartHouse.Core.Entities.Devices;

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
