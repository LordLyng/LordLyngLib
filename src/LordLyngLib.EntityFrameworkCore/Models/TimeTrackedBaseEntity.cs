using System;

namespace LordLyngLib.EntityFrameworkCore.Models
{
    public abstract class TimeTrackedBaseEntity<TKey> : BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Creation time as Unix Timestamp in milliseconds
        /// </summary>
        public virtual long CreatedAt { get; set; }

        /// <summary>
        /// Time of last update as Unix Timestamp in milliseconds
        /// </summary>
        public virtual long LastUpdatedAt { get; set; }
    }
}
