using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Rooms;
using SmartHouse.Core.Exceptions;
using SmartHouse.Core.Interfaces;
using System.Collections.Generic;

namespace SmartHouse.Core.Entities.Devices
{
    public abstract class TunableDegreesDevice : Device, ICommandable<ChangeDegreesCommand, EmptyCommandOutput>,
                                                         ICommandable<QueryDegreesCommand, DegreesStatus>
    {        
        protected int Degrees { get; private set; }
        protected int TargetDegrees { get; private set; }
        public int MinDegrees { get; }
        public int MaxDegrees { get; }

        public TunableDegreesDevice(List<CommandType> availableCommands, DeviceType deviceType,int minDegrees = int.MinValue, int maxDegrees = int.MaxValue, Room room = null, string id = null)
            : base(availableCommands, deviceType, room, id)
        {
            AvailableCommandTypes.AddRange(new List<CommandType>{ CommandType.ChangeDegrees, CommandType.QueryDegrees});
            MinDegrees = minDegrees;
            MaxDegrees = maxDegrees;
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
            if(command.TargetDegrees < MinDegrees || command.TargetDegrees > MaxDegrees)
            {
                throw new DegreesOutOfRangeException(MaxDegrees, MaxDegrees, command.TargetDegrees);
            }

            //In the real world there is a temperature change proccess.
            TargetDegrees = command.TargetDegrees;
            Degrees = command.TargetDegrees;
            return new EmptyCommandOutput();
        }

        public DegreesStatus Do(QueryDegreesCommand command)
        {
            return new DegreesStatus(Degrees);
        }
    }
}
