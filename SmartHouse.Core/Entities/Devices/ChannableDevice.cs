using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Rooms;
using SmartHouse.Core.Interfaces;
using System.Collections.Generic;

namespace SmartHouse.Core.Entities.Devices
{
    public abstract class ChannableDevice : Device, ICommandable<ChangeChannelCommand, EmptyCommandOutput>,
                                                    ICommandable<QueryChannelCommand, ChannelStatus>
    {
        protected int Channel { get; private set; }

        protected ChannableDevice(DeviceType deviceType, Room room = null, string id = null) :
            base(deviceType, room, id)
        {
            AvailableCommandTypes.AddRange(new List<CommandType>() { CommandType.ChangeChannel, CommandType.QueryChannel });
        }

        public override ICommandOutput Do(Command command)
        {
            if (command is ChangeChannelCommand changeChannelCommand)
            {
                return Do(changeChannelCommand);
            }

            if (command is QueryChannelCommand queryChannelCommand)
            {
                return Do(queryChannelCommand);
            }

            return base.Do(command);
        }

        public EmptyCommandOutput Do(ChangeChannelCommand command)
        {
            Channel = command.Channel;
            return new EmptyCommandOutput();
        }

        public ChannelStatus Do(QueryChannelCommand command)
        {
            return new ChannelStatus(Channel);
        }
    }
}
