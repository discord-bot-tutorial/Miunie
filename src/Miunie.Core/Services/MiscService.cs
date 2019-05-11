using Miunie.Core.Logging;
using System.Threading.Tasks;

namespace Miunie.Core
{
    public class MiscService
    {
        private readonly IDiscordMessages _discordMessages;
        private readonly ILogWriter _logger;

        public MiscService(IDiscordMessages discordMessages, ILogWriter logger)
        {
            _discordMessages = discordMessages;
            _logger = logger;
        }

        public async Task YesNoMaybeAnswer(MiunieChannel targetChannel) =>
            await _discordMessages.SendMessageAsync(targetChannel, PhraseKey.YES_NO_MAYBE);
    }
}
