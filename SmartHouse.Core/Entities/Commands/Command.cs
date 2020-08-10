using SmartHouse.Core.Interfaces;

namespace SmartHouse.Core.Entities.Commands
{
    public abstract class Command
    {
        public CommandType CommandType { get; }

        protected Command(CommandType commandType)
        {
            CommandType = commandType;
        }
    }
}
