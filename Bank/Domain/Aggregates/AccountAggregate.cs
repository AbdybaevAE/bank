using Bank.Domain.Event;
using Bank.Domain.Exceptions;

namespace Bank.Domain.Aggregates
{
    public class AccountState
    {
        public decimal Balance;
        public bool IsBlocked;
    }
    public class AccountAggregate
    {
        public string ExternalId { get; }
        private readonly AccountState _state = new();
        private readonly IList<IEvent> _allEvents = new List<IEvent>();
        private readonly IList<IEvent> _uncommitedEvents = new List<IEvent>();
        public AccountAggregate(string ExternalId)
        {
            this.ExternalId = ExternalId;
        }
        public void DebitAmount(decimal amount)
        {
            if (_state.IsBlocked) throw new BlockedAccountException();
            if (_state.Balance < amount) throw new InsufficientExecutionStackException();
            AddEvent(new AmountDebited(ExternalId, amount));
        }
        public void CreditAmount(decimal amount)
        {
            if (_state.IsBlocked) throw new BlockedAccountException();
            AddEvent(new AmountCredited(ExternalId, amount));
        }
        public void AddEvent(IEvent evnt)
        {
            switch (evnt)
            {
                case AmountDebited amountDebit:
                    Apply(amountDebit);
                    break;
                case AmountCredited amountCredit:
                    Apply(amountCredit);
                    break;
                default:
                    throw new Exceptions.InvalidOperationException();
            }
            _allEvents.Add(evnt);
        }
        public void Apply(AmountCredited evnt)
        {
            _state.Balance += evnt.Amount;
        }
        public void Apply(AmountDebited evnt)
        {
            _state.Balance += evnt.Amount;
        }
        public IList<IEvent> GetEvents()
        {
            return _allEvents;
        }
    }
}