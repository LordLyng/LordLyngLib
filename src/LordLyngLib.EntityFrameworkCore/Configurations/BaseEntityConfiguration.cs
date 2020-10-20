using System;
using LordLyngLib.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LordLyngLib.EntityFrameworkCore.Configurations
{
    public class BaseEntityConfiguration<TKey> : IEntityTypeConfiguration<BaseEntity<TKey>>
        where TKey : IEquatable<TKey>
        {
            public void Configure (EntityTypeBuilder<BaseEntity<TKey>> builder)
            {
                builder.HasKey (entity => entity.Id);
            }
        }
}
