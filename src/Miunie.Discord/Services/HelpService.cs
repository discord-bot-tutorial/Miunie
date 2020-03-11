using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Miunie.Core;
using Miunie.Discord.Attributes;
using Miunie.Discord.Embeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miunie.Discord
{
    public class HelpSection
    {
        public HelpSection(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public string Title { get; }
        public string Content { get; }
    }

    public class HelpResult
    {
        public HelpResult()
        {

        }

        public string Title { get; set; }
        public List<HelpSection> Sections { get; } = new List<HelpSection>();
    }

    public class HelpService
    {
        private readonly CommandService _commandService;

        public HelpService(CommandService commandService)
        {
            _commandService = commandService;
        }

        public HelpResult GetDefault()
        {
            HelpResult entry = new HelpResult();
            entry.Title = "**HELP MENU**";

            foreach (ModuleInfo module in _commandService.Modules)
            {
                string title = module.Name;
                string content = string.Join(" ", module.Commands.GroupBy(x => x.Name).Select(x => $"`{x.Key}`"));
                entry.Sections.Add(new HelpSection(title, content));
            }

            return entry;
        }

        private IEnumerable<CommandInfo> GetCommands(string input)
        {
            SearchResult result = _commandService.Search(input);

            if (!result.IsSuccess)
                throw new Exception(result.ErrorReason);

            return result.Commands.Select(x => x.Command);
        }

        private string GetSectionTitle(CommandInfo command)
            => $"{command.Name} " +
            $"{string.Join(" ", command.Parameters.OrderBy(x => x.IsOptional).Select(x => $"{(x.IsOptional ? $"[{x.Name}]" : $"<{x.Name}>")}"))}";

        private string GetExamples(CommandInfo command)
        {
            string[] examples = command.FindAttribute<ExamplesAttribute>()?.Examples;

            if (examples != null)
            {
                return string.Join(", ", examples.Select(x => $"`{x}`"));
            }

            return "No examples provided.";
        }

        private string GetSummary(CommandInfo command)
            => (command.FindAttribute<SummaryAttribute>()?.Text) ?? "No summary was provided.";

        public HelpResult Search(string input)
        {
            HelpResult entry = new HelpResult();
            
            foreach (CommandInfo command in GetCommands(input))
            {
                string title = GetSectionTitle(command);

                StringBuilder content = new StringBuilder();

                content.Append("**Summary**: ");
                string summary = GetSummary(command);
                content.AppendLine(summary);
                content.AppendLine();

                content.Append("**Examples**: ");
                string examples = GetExamples(command);
                content.Append(examples);

                entry.Sections.Add(new HelpSection(title, content.ToString()));
            }

            return entry;
        }

        public async Task ShowDefaultHelpAsync(ISocketMessageChannel channel)
        {
            await channel.SendMessageAsync(embed: EmbedConstructor.CreateHelpEmbed(GetDefault()));
        }

        public async Task ShowCommandHelpAsync(ISocketMessageChannel channel, string input)
        {
            await channel.SendMessageAsync(embed: EmbedConstructor.CreateHelpEmbed(Search(input)));
        }
    }
}
