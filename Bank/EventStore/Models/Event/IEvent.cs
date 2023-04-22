namespace Bank.EventStore.Models.Event
{
    public interface IEvent
    {
        EventType EventType { get; }
    }
    public record AmountDebited(string AccountExternalId, decimal Amount) : IEvent
    {
        public EventType EventType { get; } = EventType.AmountDebited;
    };
    public record AmountCredited(string AccountExternalId, decimal Amount) : IEvent
    {
        public EventType EventType { get; } = EventType.AmountCredited;
    };
}
