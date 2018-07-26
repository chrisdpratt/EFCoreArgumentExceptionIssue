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
    }
}
