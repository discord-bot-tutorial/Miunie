using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Miunie.Core;
using Miunie.Discord.Convertors;
using System.Threading.Tasks;

namespace Miunie.Discord.CommandModules
{
    public class Misc : BaseCommandModule
    {
        private readonly EntityConvertor _entityConvertor;
        private readonly MiscService _miscService;

        public Misc(EntityConvertor entityConvertor, MiscService miscService)
        {
            _entityConvertor = entityConvertor;
            _miscService = miscService;
        }

        [Command("what do you think?")]
        public async Task YesNoMaybeAsync(CommandContext ctx)
        {
            var channel = _entityConvertor.ConvertChannel(ctx.Channel);
            await _miscService.YesNoMaybeAnswer(channel);
        }
    }
}
