using System;
using System.Collections.Generic;

namespace Miunie.Core
{
    public class Reputation
    {

        public int Value { get; set; }
        public List<ReputationLogEntry> PlusLog { get; set; }
        public List<ReputationLogEntry> MinusLog { get; set; }

        public Reputation()
        {
            PlusLog = new List<ReputationLogEntry>();
            MinusLog = new List<ReputationLogEntry>();
        }
    }
}
