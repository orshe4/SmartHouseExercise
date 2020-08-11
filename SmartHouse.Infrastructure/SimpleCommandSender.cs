using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Devices;
using SmartHouse.Core.Interfaces;
using System.Threading.Tasks;

namespace SmartHouse.Infrastructure
{

    /// <summary>
    /// Simple command sender - In real it can be http/bluetooth Sender etc
    /// </summary>
    public class SimpleCommandSender : ICommandSender
    {                
        public Task<ICommandOutput> SendCommand(Device device, Command command)
        {            
            ICommandOutput commandOutput = device.Do(command);
            return Task.FromResult(commandOutput);
        }
    }
}