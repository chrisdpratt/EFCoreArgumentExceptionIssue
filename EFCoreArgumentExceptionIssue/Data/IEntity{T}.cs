using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreArgumentExceptionIssue.Data
{
    /// <summary>
    /// Type-specific base interface implemented by all entities.
    /// </summary>
    /// <typeparam name="T">The type of the primary key property.</typeparam>
    /// <seealso cref="IEntity" />
    public interface IEntity<out T> : IEntity
        where T : IEquatable<T>
    {
        /// <summary>
        /// Gets the primary key.
        /// </summary>
        /// <value>
        /// The primary key
        /// </value>
        new T Id { get; }
    }
}
