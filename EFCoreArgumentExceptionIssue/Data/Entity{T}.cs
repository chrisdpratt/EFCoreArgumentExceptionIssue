using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreArgumentExceptionIssue.Data
{
    /// <summary>
    /// Generic entity base class
    /// </summary>
    /// <typeparam name="T">The type of the primary key</typeparam>
    /// <seealso cref="Entity"/>
    /// <seealso cref="IEntity{T}"/>
    public abstract class Entity<T> : Entity, IEntity<T>
        where T : IEquatable<T>
    {
        /// <summary>
        /// Primary key of entity
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new T Id
        {
            get => base.Id is T id ? id : default;
            set => base.Id = value;
        }
    }
}
