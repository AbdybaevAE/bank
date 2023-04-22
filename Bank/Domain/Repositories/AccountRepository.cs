using Bank.Domain.Aggregates;
using Bank.Domain.Exceptions;
using Bank.EventStore.Models.Event;

namespace Bank.Domain.Repositories
{
    public class AccountRepository
    {
        private readonly Dictionary<string, List<IEvent>> _events = new();
        public AccountAggregate Get(string externalId)
        {
            if (!_events.ContainsKey(externalId)) throw new AccountNotFoundException();
            var accountAggregate = new AccountAggregate(externalId);

            foreach (var evnt in _events[externalId])
            {
                accountAggregate.AddEvent(evnt);
            }
            return accountAggregate;
        }
        public void Save(AccountAggregate accountAggregate)
        {
            _events[accountAggregate.ExternalId] = accountAggregate.GetEvents();
        }
    }
}
