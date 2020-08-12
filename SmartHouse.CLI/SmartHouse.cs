using McMaster.Extensions.CommandLineUtils;
using SmartHouse.CLI.Commands;
using SmartHouse.Core.Interfaces;
using System.Threading.Tasks;

namespace SmartHouse.CLI
{
    [Command("SmartHouse")]
    [Subcommand(typeof(TurnOnCommand), typeof(TurnOffCommand), typeof(QueryActivityCommand))]
    class SmartHouse : BaseCommand
    {
        public SmartHouse(ISmartHouseService smartHouseService) : base(smartHouseService)
        {
            SmartHouseService = smartHouseService;
        }

        protected override Task<int> OnExecute(CommandLineApplication app)
        {
            // this shows help even if the --help option isn't specified
            app.ShowHelp();
            return Task.FromResult(1);
        }
    }
}
