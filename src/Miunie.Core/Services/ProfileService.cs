using Miunie.Core.Logging;
using Miunie.Core.Providers;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Miunie.Core
{
    public class ProfileService
    {
        private readonly IDiscordMessages _discordMessages;
        private readonly IUserReputationProvider _reputationProvider;
        private readonly ILogger _logger;

        public ProfileService(IDiscordMessages discordMessages, IUserReputationProvider reputationProvider, ILogger logger)
        {
            _discordMessages = discordMessages;
            _reputationProvider = reputationProvider;
            _logger = logger;
        }

        public async Task ShowProfileAsync(MiunieUser user, MiunieChannel c)
            => await _discordMessages.SendMessageAsync(c, user);

        public async Task GiveReputationAsync(MiunieUser invoker, MiunieUser target, MiunieChannel c, string reason)
        {
            if (invoker.Id == target.Id)
            {
                await _discordMessages.SendMessageAsync(c, PhraseKey.CANNOT_SELF_REP, invoker.Name);
                return;
            }

            if (_reputationProvider.AddReputationHasTimeout(invoker, target))
            {
                _logger.Log($"User '{invoker.Name}' has a reputation timeout for User '{target.Name}', ignoring...");
                return;
            }

            _reputationProvider.AddReputation(invoker, target, reason);
            await _discordMessages.SendMessageAsync(c, PhraseKey.REPUTATION_GIVEN, target.Name, invoker.Name);
        }

        public async Task RemoveReputationAsync(MiunieUser invoker, MiunieUser target, MiunieChannel c, string reason)
        {
            if (invoker.Id == target.Id)
            {
                await _discordMessages.SendMessageAsync(c, PhraseKey.CANNOT_SELF_REP, invoker.Name);
                return;
            }

            if (_reputationProvider.RemoveReputationHasTimeout(invoker, target)) { return; }

            _reputationProvider.RemoveReputation(invoker, target, reason);
            await _discordMessages.SendMessageAsync(c, PhraseKey.REPUTATION_TAKEN, invoker.Name, target.Name);
        }

        public async Task ShowReputationHistoryAsync(MiunieUser target, MiunieChannel channel)
        {
            var history = GetReputationHistory(target);
            if(history.Count() == 0)
            {
                await _discordMessages.SendMessageAsync(channel, PhraseKey.USER_REP_LOG_SHOW_EMPTY, target.Name);
                return;
            }
            
            var header = new TranslateRequest
            {
                PhraseKey = PhraseKey.USER_REP_LOG_SHOW,
                Parameters = new string[] { target.Name }
            };
            var toShow = history
                .Take(5)
                .Prepend(header)
                .ToArray();
           await _discordMessages.SendMessageAsync(channel, toShow);
        }

        private TranslateRequest GetTranslateRequestFrom(ReputationLogEntry e)
        {
            var request = new TranslateRequest();
            request.PhraseKey = PhraseKey.USER_REP_LOG_ENTRY;
            var repSign = e.Operation == ReputationOperation.Add ? "+" : "-";
            
            //TODO(Charly): This needs to be translated!
            var reason = string.IsNullOrEmpty(e.Reason) ? "No reason provided" : e.Reason;
            request.Parameters = new string[] 
            {
                repSign, 
                e.Invoker.Name, 
                e.Date.ToShortDateString(),
                reason
            };
            return request;
        }
        private TranslateRequest[] GetReputationHistory(MiunieUser m)
        {
            return m.Reputation.PlusLog
                .Concat(m.Reputation.MinusLog)
                .OrderByDescending(e => e.Date)
                .Select(e => GetTranslateRequestFrom(e))
                .ToArray();  
        }

        public async Task ShowGuildProfileAsync(MiunieGuild guild, MiunieChannel c)
            => await _discordMessages.SendMessageAsync(c, guild);
    }
}
