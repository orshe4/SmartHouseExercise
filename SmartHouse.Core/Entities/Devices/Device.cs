using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Rooms;
using SmartHouse.Core.Exceptions;
using SmartHouse.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace SmartHouse.Core.Entities.Devices
{
    public abstract class Device : ICommandable<TurnOffCommand, EmptyCommandOutput>,
                                   ICommandable<TurnOnCommand, EmptyCommandOutput>,
                                   ICommandable<QueryActivityStatusCommand, ActivityStatus>
    {
        public string Id { get; }
        protected List<CommandType> AvailableCommandTypes { get; }
        public DeviceType DeviceType { get; }
        public bool IsActive { get; private set; }
        public Room Room { get; private set; }

        protected Device(DeviceType deviceType, Room room = null, string id = null)
        {
            Id = id ?? Guid.NewGuid().ToString();
            AvailableCommandTypes = new List<CommandType>() { CommandType.TurnOff, CommandType.TurnOn, CommandType.QueryActivityStatus};
            DeviceType = deviceType;
            Room = room;
        }

        public bool CanExecuteCommand(Command command)
        {
            return AvailableCommandTypes.Contains(command.CommandType);
        }

        public void ChangeRoom(Room room)
        {
            Room = room;
        }

        public virtual ICommandOutput Do(Command command)
        {
            if (command is TurnOffCommand turnOffCommand)
            {
                return Do(turnOffCommand);
            }
            else if (command is TurnOnCommand turnOnCommand)
            {
                return Do(turnOnCommand);
            }
            else if(command is QueryActivityStatusCommand activityStatusCommand)
            {
                return Do(activityStatusCommand);
            }

            throw new NotCompatibleCommandException(this, command);
        }

        #region Commands
        public virtual EmptyCommandOutput Do(TurnOffCommand command)
        {
            IsActive = false;
            return new EmptyCommandOutput();
        }

        public virtual EmptyCommandOutput Do(TurnOnCommand command)
        {
            IsActive = true;
            return new EmptyCommandOutput();
        }

        public virtual ActivityStatus Do(QueryActivityStatusCommand command)
        {
            return new ActivityStatus(IsActive);
        }
        #endregion
    }
}
