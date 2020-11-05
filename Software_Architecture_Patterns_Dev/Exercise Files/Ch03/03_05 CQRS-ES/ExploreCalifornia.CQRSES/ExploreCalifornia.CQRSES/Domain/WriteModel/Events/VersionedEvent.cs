using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.CQRSES.Domain.Events
{
    public class VersionedEvent
    {
        /// <summary>
        /// The id of the entity that this event belongs to.
        /// </summary>
        public Guid EntityId { get; set; }

        /// <summary>
        /// This property indicates the version of the aggregate that this event applies to.
        /// It can be used to order the events, or to implement a system of optimistic concurrency.
        /// </summary>
        public int Version { get; set; }
    }
}
