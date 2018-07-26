using System;
using System.ComponentModel.DataAnnotations;

namespace EFCoreArgumentExceptionIssue.Data
{
    /// <summary>
    /// Base interface used by all entities
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets the primary key as an object.
        /// </summary>
        /// <value>
        /// The primary key as an object.
        /// </value>
        object Id { get; }

        /// <summary>
        /// Gets the date/time the entity was created.
        /// </summary>
        /// <value>
        /// The created data/time.
        /// </value>
        DateTimeOffset Created { get; }

        /// <summary>
        /// Gets the name of the creator of the entity.
        /// </summary>
        /// <value>
        /// The name of the creator.
        /// </value>
        string CreatedBy { get; }

        /// <summary>
        /// Gets the last date/time the entity was modified.
        /// </summary>
        /// <value>
        /// The last modification date/time.
        /// </value>
        DateTimeOffset? Modified { get; }

        /// <summary>
        /// Gets the name of the last modifier of the entity.
        /// </summary>
        /// <value>
        /// The name of the last modifier.
        /// </value>
        string ModifiedBy { get; }

        /// <summary>
        /// Gets the version (for optimistic concurrency).
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [Timestamp]
        byte[] Version { get; }
    }
}
