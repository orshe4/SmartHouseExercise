namespace SmartHouse.Core.Entities.Commands
{
    public class ChangeChannelCommand : Command
    {
        public int Channel { get; }
        public ChangeChannelCommand(int channel) : base(CommandType.ChangeChannel)
        {
            Channel = channel;
        }
    }
}
