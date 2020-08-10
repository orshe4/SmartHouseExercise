using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Devices;
using System.Threading.Tasks;

namespace SmartHouse.Core.Interfaces
{
    /// <summary>
    /// Responsible to send commands to devices and receive theirs output
    /// </summary>
    public interface ICommandSender
    {
        Task<ICommandOutput> SendCommand(Device device, Command command);
    }
}
