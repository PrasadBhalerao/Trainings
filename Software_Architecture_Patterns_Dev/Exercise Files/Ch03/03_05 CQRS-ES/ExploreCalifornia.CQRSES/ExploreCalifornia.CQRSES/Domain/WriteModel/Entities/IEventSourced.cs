using ExploreCalifornia.CQRSES.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.CQRSES.Domain.Entities
{
    public interface IEventSourced
    {
        /// <summary>
        /// The id of the event sourced object.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets the entity's version. As the entity is being updated and events being generated, the version is incremented.
        /// </summary>
        int Version { get; }

        /// <summary>
        /// Gets the collection of new events since the entity was loaded, as a consequence of command handling.
        /// </summary>
        IEnumerable<VersionedEvent> PendingEvents { get; }
    }
}
