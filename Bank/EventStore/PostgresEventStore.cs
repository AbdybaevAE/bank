using Bank.EventStore.Models.Event;

namespace Bank.EventStore
{
    public class PostgresEventStore : IEventStore
    {
        private readonly PostgresDbContext _dbContext;
        public PostgresEventStore(PostgresDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Event> Load(Guid aggregateId)
        {
            return _dbContext.Events
                            .Where(b => b.AggregateId.Equals(aggregateId))
                            .ToList();
        }

        public void Save(List<Event> events)
        {
            _dbContext.AddRange(events.ToList());
            _dbContext.SaveChanges();
        }
    }
}
