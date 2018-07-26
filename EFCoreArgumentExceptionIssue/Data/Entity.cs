using NodaTime;
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
        internal IClock clock;

        protected Entity()
            : this(SystemClock.Instance)
        {
        }

        internal Entity(IClock clock)
        {
            SetClock(clock);
        }

        internal void SetClock(IClock clock)
        {
            this.clock = clock;
        }

        /// <summary>
        /// Primary key of entity
        /// </summary>
        public object Id { get; set; }

        /// <summary>
        /// Date/time the record was created
        /// </summary>
        public DateTimeOffset Created { get; internal set; }

        /// <summary>
        /// Date/time the record was created
        /// </summary>
        /// <value>NodaTime <see cref="ZonedDateTime"/></value>
        [NotMapped]
        public ZonedDateTime CreatedZoned
        {
            get => ZonedDateTime.FromDateTimeOffset(Created);
            internal set => Created = value.ToDateTimeOffset();
        }

        /// <summary>
        /// User the record was created by
        /// </summary>
        [StringLength(50)]
        public string CreatedBy { get; internal set; }

        /// <summary>
        /// Last date/time the record was modified
        /// </summary>
        public DateTimeOffset? Modified { get; internal set; }

        /// <summary>
        /// Date/time the record was modified
        /// </summary>
        /// <value>NodaTime <see cref="ZonedDateTime"/></value>
        [NotMapped]
        public ZonedDateTime? ModifiedZoned
        {
            get => Modified.HasValue ? ZonedDateTime.FromDateTimeOffset(Modified.Value) : default(ZonedDateTime?);
            internal set => Modified = value?.ToDateTimeOffset();
        }

        /// <summary>
        /// User who last modified the record
        /// </summary>
        [StringLength(50)]
        public string ModifiedBy { get; internal set; }

        /// <summary>
        /// Record version (used for optimistic concurrency)
        /// </summary>
        [Timestamp]
        public byte[] Version { get; internal set; }

        /// <summary>
        /// Set the creation details of the record using provided time zone.
        /// </summary>
        /// <param name="createdBy">User who is creating the record</param>
        /// <param name="tz">Time zone to set created date in</param>
        public void SetCreated(string createdBy, string tz = "UTC")
        {
            if (CreatedBy != null)
            {
                throw new InvalidOperationException("Record already has creation details.");
            }

            CreatedBy = createdBy ?? throw new ArgumentNullException(nameof(createdBy));
            CreatedZoned = clock.GetCurrentInstant().InZone(DateTimeZoneProviders.Tzdb.GetZoneOrNull(tz));
        }

        /// <summary>
        /// Set the modifcation details of the record using provided time zone.
        /// </summary>
        /// <param name="modifiedBy"></param>
        /// <param name="tz">Time zone to set modified date in</param>
        public void SetModified(string modifiedBy, string tz = "UTC")
        {
            if (CreatedBy == null)
            {
                throw new InvalidOperationException("Record does not have creation details.");
            }

            ModifiedBy = modifiedBy ?? throw new ArgumentNullException(nameof(modifiedBy));
            ModifiedZoned = clock.GetCurrentInstant().InZone(DateTimeZoneProviders.Tzdb.GetZoneOrNull(tz));
        }
    }
}
