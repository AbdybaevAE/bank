using System;
using Bank.EventStore;
using Bank.EventStore.Models.Event;
using Bank.Tests.Lib;
using Bank.Tests.Lib.Categories;
using Microsoft.Extensions.Configuration;

namespace Bank.Tests.EventStore
{
    public class EventStoreIntegration_Tests : PostgresContainer
    {
        private IEventStore eventStore;
        public EventStoreIntegration_Tests() : base("Resources/create_event_store_relations.sql") { }
        protected override void OnContainerUp()
        {
            var settings = new Dictionary<string, string>() {
                {"EventStore:ConnectionString", CurrentContainer.GetConnectionString()}
            };
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(settings).Build();
            var dbContext = new PostgresDbContext(configuration);
            eventStore = new PostgresEventStore(dbContext);
        }

        [Category(TestCategory.Integration)]
        [Fact]
        public void ShouldPersistEventsCorrectly_Test()
        {
            var events = new List<Event>(){
                new Event{
                    Id = Guid.NewGuid(),
                    AggregateId = Guid.NewGuid(),
                    EventType = EventType.AccountCreated,
                    Payload = "Some payload"
                }
            };
            eventStore.Save(events);
        }
    }
}
