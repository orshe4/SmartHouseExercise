using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Commands.Output;
using SmartHouse.Core.Entities.Devices;
using SmartHouse.Core.Exceptions;
using SmartHouse.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHouse.Infrastructure
{

    /// <summary>
    /// Simple command sender - In real it can be httpSender etc
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