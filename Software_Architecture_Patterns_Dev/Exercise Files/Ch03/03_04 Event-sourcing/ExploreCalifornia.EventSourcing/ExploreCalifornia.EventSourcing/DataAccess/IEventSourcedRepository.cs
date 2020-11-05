using ExploreCalifornia.EventSourcing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.EventSourcing.DataAccess
{
    public interface IEventSourcedRepository<T> where T : IEventSourced
    {
        /// <summary>
        /// Tries to retrieve the event sourced entity.
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns>The hydrated entity, or null if it does not exist.</returns>
        T Get(Guid id);

        /// <summary>
        /// Saves the event sourced entity.
        /// </summary>
        /// <param name="eventSourced">The entity.</param>
        void Save(T eventSourced);
    }
}
