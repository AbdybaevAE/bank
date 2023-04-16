using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Domain.Event
{
    public interface IEvent
    {
        EventTypes EventType { get; }
    }
    public record AmountDebited(string AccountExternalId, decimal Amount) : IEvent
    {
        public EventTypes EventType { get; } = EventTypes.AmountDebited;
    };
    public record AmountCredited(string AccountExternalId, decimal Amount) : IEvent
    {
        public EventTypes EventType { get; } = EventTypes.AmountCredited;
    };
}