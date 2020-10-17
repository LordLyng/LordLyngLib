using System;
using LordLyngLib.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LordLyngLib.EntityFrameworkCore.Configurations
{
    public class EntityConfiguration<TKey> : IEntityTypeConfiguration<Entity<TKey>>
        where TKey : IEquatable<TKey>
        {
            public void Configure (EntityTypeBuilder<Entity<TKey>> builder)
            {
                builder.HasKey (entity => entity.Id);
            }
        }
}
