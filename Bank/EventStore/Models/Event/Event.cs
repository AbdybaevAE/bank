using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.EventStore.Models.Event
{
    [Table("events")]
    public class Event
    {
        [Column("event_id")]
        public Guid Id { get; set; }
        [Column("event_type")]
        public EventType EventType { get; set; }
        [Column("aggregate_id")]
        public Guid AggregateId { get; set; }
        [Column("event_payload")]
        public string Payload { get; set; }
    }
}
