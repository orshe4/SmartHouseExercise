namespace SmartHouse.Core.Entities.Commands
{
    public class TurnOnCommand : Command
    {
        public TurnOnCommand() : base(CommandType.TurnOff) { }
    }
}
