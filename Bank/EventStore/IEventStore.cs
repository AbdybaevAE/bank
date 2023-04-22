using Bank.EventStore.Models.Event;

namespace Bank.EventStore
{
    public interface IEventStore
    {
        List<Event> Load(Guid aggregateId);
        void Save(List<Event> events);
    }
}
