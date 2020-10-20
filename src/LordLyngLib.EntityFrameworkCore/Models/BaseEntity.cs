using System;

namespace LordLyngLib.EntityFrameworkCore.Models
{
    public abstract class BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}
