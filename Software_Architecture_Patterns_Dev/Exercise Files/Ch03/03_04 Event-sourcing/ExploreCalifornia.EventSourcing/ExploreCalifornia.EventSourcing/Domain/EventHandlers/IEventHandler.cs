using ExploreCalifornia.EventSourcing.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.EventSourcing.Domain.EventHandlers
{
    /// <summary>
    /// Marker interface to allow dependency injection of all event handlers.
    /// </summary>
    public interface IEventHandler { }

    /// <summary>
    /// Interface to implement for event handlers that will be called when an event is persisted.
    /// </summary>
    public interface IEventHandler<in T> : IEventHandler where T : VersionedEvent
    {
        void Handle(T e);
    }
}
