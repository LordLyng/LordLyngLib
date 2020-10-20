using System;
using System.Diagnostics.CodeAnalysis;
using LordLyngLib.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace LordLyngLib.EntityFrameworkCore.Configurations
{
    public class TimeTrackedBaseEntityConfiguration<TKey> : IEntityTypeConfiguration<TimeTrackedBaseEntity<TKey>>
        where TKey : IEquatable<TKey>
        {
            public void Configure (EntityTypeBuilder<TimeTrackedBaseEntity<TKey>> builder)
            {
                builder.HasBaseType<BaseEntity<TKey>> ();
                builder.Property (entity => entity.CreatedAt)
                    .ValueGeneratedOnAdd ()
                    .HasValueGenerator<UtcNowGenerator> ();
                builder.Property (entity => entity.LastUpdatedAt)
                    .ValueGeneratedOnUpdate ()
                    .HasValueGenerator<UtcNowGenerator> ();
            }
        }

    internal class UtcNowGenerator : ValueGenerator<long>
    {
        public override bool GeneratesTemporaryValues => false;

        public override long Next ([NotNull] EntityEntry entry)
        {
            if (entry is null)
            {
                throw new ArgumentNullException (nameof (entry));
            }

            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds ();
        }
    }
}
