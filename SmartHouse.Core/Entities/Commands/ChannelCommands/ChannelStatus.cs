using SmartHouse.Core.Interfaces;

namespace SmartHouse.Core.Entities.Commands
{
    public class ChannelStatus : ICommandOutput
    {
        public int Channel { get; }

        public ChannelStatus(int channel)
        {
            Channel = channel;
        }
    }
}
