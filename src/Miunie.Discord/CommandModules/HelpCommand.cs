using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Miunie.Core;
using Miunie.Discord.Convertors;
using System.Threading.Tasks;

// TODO: remove HelpEntry and HelpSection, as IDiscord can handle
// sending messages.
namespace Miunie.Discord.CommandModules
{
    public class HelpCommand : ModuleBase<SocketCommandContext>
    {
        private readonly EntityConvertor _entityConvertor;
        private readonly HelpService _helpService;

        public HelpCommand(CommandHandler commandHandler, EntityConvertor entityConvertor)
        {
            _helpService = commandHandler.GetHelpService();
            _entityConvertor = entityConvertor;
        }

        [Command("help")]
        public async Task GetHelp()
        {
            await _helpService.ShowDefaultHelpAsync(Context.Channel);
        }

        [Command("help")]
        public async Task GetHelp([Remainder]string input)
        {
            await _helpService.ShowCommandHelpAsync(Context.Channel, input);
        }
    }
}
