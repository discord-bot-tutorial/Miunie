using System;

namespace Miunie.Core
{
    public class ReputationLogEntry
    {
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public MiunieUser Invoker { get; set; }
        public ReputationOperation Operation { get; set; }
    }

    public enum ReputationOperation
    {
        Add,
        Remove
    }
}
