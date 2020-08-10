namespace SmartHouse.Core.Entities.Commands
{
    public class ChangeDegreesCommand : Command
    {
        public int TargetDegrees { get; }

        public ChangeDegreesCommand() : base(CommandType.ChangeDegrees)
        {
        }
    }
}
