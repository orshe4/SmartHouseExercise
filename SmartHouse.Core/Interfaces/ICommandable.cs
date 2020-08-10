using SmartHouse.Core.Entities.Commands;

namespace SmartHouse.Core.Interfaces
{
    public interface ICommandable<TCommand, TCommandOutput> where TCommand : Command
                                                     where TCommandOutput : ICommandOutput
    {
        TCommandOutput Do(TCommand command);
    }
}
