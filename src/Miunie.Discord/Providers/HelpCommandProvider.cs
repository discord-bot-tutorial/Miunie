// This file is part of Miunie.
//
//  Miunie is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  Miunie is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with Miunie. If not, see <https://www.gnu.org/licenses/>.

using Discord.Commands;
using Discord.WebSocket;
using Miunie.Core.Entities;
using Miunie.Core.Providers;
using Miunie.Discord.Attributes;
using Miunie.Discord.Embeds;
using Miunie.Discord.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miunie.Discord
{
    public class HelpCommandProvider
    {
        private readonly CommandService _commandService;
        private readonly ILanguageProvider _lang;

        public HelpCommandProvider(CommandService commandService, ILanguageProvider lang)
        {
            _commandService = commandService;
            _lang = lang;
        }

        public HelpResult GetDefault()
            => new HelpResult
            {
                Title = _lang.GetPhrase(PhraseKey.USER_EMBED_HELP_TITLE.ToString()),
                Sections = _commandService.Modules.Select(x => GetSection(x))
            };

        public HelpResult Search(string input)
            => new HelpResult()
            {
                Sections = GetCommands(input).Select(x => GetSection(x))
            };

        public async Task ShowDefaultHelpAsync(ISocketMessageChannel channel)
            => await channel.SendMessageAsync(embed: EmbedConstructor.CreateHelpEmbed(GetDefault()));

        public async Task ShowCommandHelpAsync(ISocketMessageChannel channel, string input)
            => await channel.SendMessageAsync(embed: EmbedConstructor.CreateHelpEmbed(Search(input)));

        private IEnumerable<CommandInfo> GetCommands(string input)
        {
            SearchResult result = _commandService.Search(input);

            if (!result.IsSuccess)
            {
                throw new Exception(result.ErrorReason);
            }

            return result.Commands.Select(x => x.Command);
        }

        private HelpSection GetSection(ModuleInfo module)
            => new HelpSection(module.Name, GetModuleCommandBlocks(module));

        private string GetModuleCommandBlocks(ModuleInfo module)
            => string.Join(" ", module.Commands
                .GroupBy(x => x.Name)
                .Select(x => $"`{x.Key}`"));

        private HelpSection GetSection(CommandInfo command)
        {
            string title = GetSectionTitle(command);
            string summary = GetSummary(command);
            string examples = GetExamples(command);

            var content = new StringBuilder();

            _ = content.Append(_lang.GetPhrase(PhraseKey.HELP_SUMMARY_TITLE.ToString()))
                .AppendLine(summary)
                .Append(_lang.GetPhrase(PhraseKey.HELP_EXAMPLE_TITLE.ToString()))
                .Append(examples);

            return new HelpSection(title, content.ToString());
        }

        private string GetSectionTitle(CommandInfo command)
            => $"{command.Name} {GetSectionParameters(command)}";

        private string GetSectionParameters(CommandInfo command)
            => string.Join(" ", command.Parameters
                .OrderBy(x => x.IsOptional)
                .Select(x => x.IsOptional ? $"[{x.Name}]" : $"<{x.Name}>"));

        private string GetExamples(CommandInfo command)
            => command.FindAttribute<ExamplesAttribute>()?.Examples
                .StringJoinOrDefault(x => $"`{x}`", ", ", _lang.GetPhrase(PhraseKey.HELP_EXAMPLE_EMPTY.ToString()));

        private string GetSummary(CommandInfo command)
            => command.Summary.ValueOrDefault(_lang.GetPhrase(PhraseKey.HELP_SUMMARY_EMPTY.ToString()));
    }
}
