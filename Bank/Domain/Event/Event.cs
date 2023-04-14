using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Domain.Event
{
    public class Event
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Payload { get; set; }
        public string AggregateId { get; set; }
    }
}