using ExploreCalifornia.CQRSES.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.CQRSES.Domain.Entities
{
    public abstract class EventSourced : IEventSourced
    {
        private readonly Dictionary<Type, Action<VersionedEvent>> _handlers = new Dictionary<Type, Action<VersionedEvent>>();
        private readonly List<VersionedEvent> _pendingEvents = new List<VersionedEvent>();

        protected EventSourced(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// The id of the event sourced object.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the entity's version. As the entity is being updated and events being generated, the _version is incremented.
        /// </summary>
        public int Version { get; protected set; } = -1;

        /// <summary>
        /// Gets the collection of new events since the entity was loaded, as a consequence of command handling.
        /// </summary>
        public IEnumerable<VersionedEvent> PendingEvents => _pendingEvents;

        /// <summary>
        /// Configures a handler for an event. 
        /// </summary>
        protected void Handles<TEvent>(Action<TEvent> handler)
            where TEvent : VersionedEvent
        {
            _handlers.Add(typeof(TEvent), @event => handler((TEvent)@event));
        }

        /// <summary>
        /// Rehydrates an object, i.e. sets a new object to its last state given past events by replaying those events.
        /// </summary>
        /// <param name="pastEvents"></param>
        protected void LoadFrom(IEnumerable<VersionedEvent> pastEvents)
        {
            foreach (var e in pastEvents)
            {
                _handlers[e.GetType()].Invoke(e);
                Version = e.Version;
            }
        }

        /// <summary>
        /// Adds the event to the list of pending events and triggers the correct handler method.
        /// </summary>
        /// <param name="e"></param>
        protected void Update(VersionedEvent e)
        {
            e.EntityId = Id;
            e.Version = Version + 1;
            _handlers[e.GetType()].Invoke(e);
            Version = e.Version;
            _pendingEvents.Add(e);
        }
    }
}
