using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Commands.Output;
using SmartHouse.Core.Entities.Rooms;
using SmartHouse.Core.Interfaces;
using System.Collections.Generic;

namespace SmartHouse.Core.Entities.Devices
{
    internal class TunableDegreesDevice : Device, ICommandable<ChangeDegreesCommand, EmptyCommandOutput>
    {
        protected int Degrees { get; private set; }
        protected int TargetDegrees { get; private set; }

        public TunableDegreesDevice(List<CommandType> availableCommands, DeviceType deviceType, Room room = null, string id = null)
            : base(availableCommands, deviceType, room, id)
        {
            AvailableCommandTypes.Add(CommandType.ChangeDegrees);
        }

        public override ICommandOutput Do(Command command)
        {
            if (command is ChangeDegreesCommand changeDegreesCommand)
            {
                return Do(changeDegreesCommand);
            }

            return base.Do(command);
        }

        public virtual EmptyCommandOutput Do(ChangeDegreesCommand command)
        {
            //In the real world there is a temperature change proccess.
            TargetDegrees = command.TargetDegrees;
            Degrees = command.TargetDegrees;
            return new EmptyCommandOutput();
        }
    }
}
