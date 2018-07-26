using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;

namespace EFCoreArgumentExceptionIssue.Data
{
    /// <summary>
    /// Base entity class. Primarily used as a type-contraint for generic
    /// classes and methods, when the type of <see cref="Id"/> does not matter.
    /// Entity classes should inherit from <see cref="Entity{T}"/> rather than
    /// this class.
    /// </summary>
    public abstract class Entity : IEntity
    {
        /// <summary>
        /// Primary key of entity
        /// </summary>
        public object Id { get; set; }
    }
}
