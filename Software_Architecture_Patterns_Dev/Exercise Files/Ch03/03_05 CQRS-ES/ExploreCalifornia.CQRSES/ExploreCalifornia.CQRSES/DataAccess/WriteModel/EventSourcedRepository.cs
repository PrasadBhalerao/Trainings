using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Newtonsoft.Json;
using ExploreCalifornia.CQRSES.Domain.WriteModel.EventHandlers;
using System.Reflection;
using ExploreCalifornia.CQRSES.Domain.Entities;
using ExploreCalifornia.CQRSES.Domain.Events;

namespace ExploreCalifornia.CQRSES.DataAccess.WriteModel
{
    public class EventSourcedRepository<T> : IEventSourcedRepository<T> where T : class, IEventSourced
    {
        private string _connectionString;
        private JsonSerializerSettings _jsonSettings;
        private IEnumerable<IEventHandler> _eventHandlers;

        public EventSourcedRepository(IEnumerable<IEventHandler> eventHandlers)
        {
            _connectionString = "Data Source=AppData/CQRSES-database.db;";
            _jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            };

            _eventHandlers = eventHandlers;
        }

        /// <summary>
        /// Tries to retrieve the event sourced entity.
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns>The hydrated entity, or null if it does not exist.</returns>
        public T Get(Guid id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var eventRecords = connection.Query<EventRecord>("SELECT Id, EntityId, EntityType, Version, Payload, Timestamp " +
                    "FROM Event " +
                    "WHERE EntityType = @EntityType AND EntityId = @EntityId " +
                    "ORDER BY Version", new { EntityType = typeof(T).Name, EntityId = id }).ToList();

                var versionedEvents = eventRecords.Select(Deserialize).ToList();

                if (!versionedEvents.Any())
                {
                    return null;
                }

                var constructor = typeof(T).GetConstructor(new[] { typeof(Guid), typeof(IEnumerable<VersionedEvent>) });
                if (constructor == null)
                {
                    throw new InvalidCastException($"Type {typeof(T)} must have a constructor with the following signature: .ctor(Guid, IEnumerable<VersionedEvent>)");
                }

                return (T)constructor.Invoke(new object[] { id, versionedEvents });
            }
        }

        public void Save(T eventSourced)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                foreach (var pendingEvent in eventSourced.PendingEvents)
                {
                    var record = Serialize(pendingEvent);

                    connection.Execute(
                        "INSERT INTO Event (EntityId, EntityType, Version, Payload, Timestamp) VALUES (@EntityId, @EntityType, @Version, @Payload, @Timestamp)",
                        new
                        {
                            EntityId = record.EntityId,
                            EntityType = record.EntityType,
                            Version = record.Version,
                            Payload = record.Payload,
                            Timestamp = record.Timestamp
                        });

                    foreach (var eventHandler in _eventHandlers)
                    {
                        var handleMethod = eventHandler.GetType()
                            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                            .SingleOrDefault(m => m.Name == "Handle" && m.GetParameters().Length == 1 && m.GetParameters().Single().ParameterType == pendingEvent.GetType());

                        if (handleMethod == null)
                        {
                            continue;
                        }

                        handleMethod.Invoke(eventHandler, new[] { pendingEvent });
                    }
                }
            }
        }

        private EventRecord Serialize(VersionedEvent e)
        {
            var eventRecord = new EventRecord
            {
                EntityId = e.EntityId,
                EntityType = typeof(T).Name,
                Version = e.Version,
                Payload = JsonConvert.SerializeObject(e, _jsonSettings),
                Timestamp = DateTime.UtcNow
            };

            return eventRecord;
        }

        private VersionedEvent Deserialize(EventRecord e)
        {
            var deserializedObject = JsonConvert.DeserializeObject<VersionedEvent>(e.Payload, _jsonSettings);
            return deserializedObject;
        }
    }
}
