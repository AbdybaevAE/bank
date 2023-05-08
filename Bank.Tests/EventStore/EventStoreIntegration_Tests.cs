using Bank.EventStore;
using Bank.EventStore.Models.Event;
using Bank.Tests.LibTest;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;

namespace Bank.Tests.EventStore
{
    [Collection("Persistence collection")]
    public class EventStoreIntegration_Tests : IDisposable
    {
        private readonly IEventStore _eventStore;
        private readonly ITestOutputHelper _output;
        private readonly PersistenceFixture _persistenceFixture;
        public EventStoreIntegration_Tests(PersistenceFixture persistenceFixture, ITestOutputHelper output)
        {
            _output = output;
            _persistenceFixture = persistenceFixture;
            _persistenceFixture.SeedData();
            var settings = new Dictionary<string, string>() {
                {"EventStore:ConnectionString", _persistenceFixture.Container.GetConnectionString()}
            };
#pragma warning disable CS8620
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(settings).Build();
            var dbContext = new PostgresDbContext(configuration);
            _eventStore = new PostgresEventStore(dbContext);
        }

        public void Dispose()
        {
            _persistenceFixture.ClearData();
        }
        [Fact]
        public void ShouldPersistEventsCorrectly_Test()
        {
            // Given
            var events = new List<Event>(){
                new Event{
                    Id = Guid.NewGuid(),
                    AggregateId = Guid.NewGuid(),
                    EventType = EventType.AccountCreated,
                    Payload = "Some payload"
                }
            };

            // When
            _eventStore.Save(events);

        }
    }
}
