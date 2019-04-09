namespace Miunie.Core.Providers
{
    public interface IUserReputationProvider
    {
        void AddReputation(MiunieUser invoker, MiunieUser target, string reason);
        void RemoveReputation(MiunieUser invoker, MiunieUser target, string reason);
        bool AddReputationHasTimeout(MiunieUser invoker, MiunieUser target);
        bool RemoveReputationHasTimeout(MiunieUser invoker, MiunieUser target);
    }
}
