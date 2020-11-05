using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.EventSourcing.DataAccess
{
    public class EventRecord
    {
        public int Id { get; set; }
        public Guid EntityId { get; set; }
        public string EntityType { get; set; }
        public int Version { get; set; }
        public string Payload { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
