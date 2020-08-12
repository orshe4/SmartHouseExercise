using McMaster.Extensions.CommandLineUtils;
using SmartHouse.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.CLI.Commands
{
    /// <summary>
    /// This base type provides shared functionality.
    /// Also, declaring <see cref="HelpOptionAttribute"/> on this type means all types that inherit from it
    /// will automatically support '--help'
    /// </summary>
    [HelpOption("--help")]
    abstract class BaseCommand
    {
        protected ISmartHouseService SmartHouseService;
        public BaseCommand(ISmartHouseService smartHouseService)
        {
            SmartHouseService = smartHouseService;
        }

        protected abstract Task<int> OnExecute(CommandLineApplication app);
    }
}
