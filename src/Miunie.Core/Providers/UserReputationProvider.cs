using System;
using System.Linq;
using System.Collections.Generic;
using Miunie.Core.Infrastructure;

namespace Miunie.Core.Providers
{
    public class UserReputationProvider : IUserReputationProvider
    {
        private const int TimeoutInSeconds = 1800;

        private readonly IMiunieUserProvider _userProvider;
        private readonly IDateTime _dateTime;

        public UserReputationProvider(IMiunieUserProvider userProvider, IDateTime dateTime)
        {
            _userProvider = userProvider;
            _dateTime = dateTime;
        }

        public void AddReputation(MiunieUser invoker, MiunieUser target, string reason ="")
        {
            target.Reputation.Value++;
            var logEntry = new ReputationLogEntry
            {
                Invoker = invoker,
                Date = _dateTime.Now,
                Reason = reason,
                Operation = ReputationOperation.Add
            };
            target.Reputation.PlusLog.Add(logEntry);
            _userProvider.StoreUser(target);
        }

        public void RemoveReputation(MiunieUser invoker, MiunieUser target, string reason = "")
        {
            target.Reputation.Value--;
            var logEntry = new ReputationLogEntry
            {
                Invoker = invoker,
                Date = _dateTime.Now,
                Reason = reason,
                Operation = ReputationOperation.Remove
            };
            target.Reputation.MinusLog.Add(logEntry);
            _userProvider.StoreUser(target);
        }

        public bool AddReputationHasTimeout(MiunieUser invoker, MiunieUser target)
            => HasTimeout(target.Reputation.PlusLog, invoker);

        public bool RemoveReputationHasTimeout(MiunieUser invoker, MiunieUser target)
            => HasTimeout(target.Reputation.MinusLog, invoker);

        private bool HasTimeout(List<ReputationLogEntry> log, MiunieUser invoker)
        {
            var lastRep = log.LastOrDefault(l => l.Invoker.Id == invoker.Id);
            if(lastRep is null)
            {
                return false;
            }
            if ((_dateTime.Now - lastRep.Date).TotalSeconds <= TimeoutInSeconds)
            {
                return true;
            }
            return false;
        }
    }
}
