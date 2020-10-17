using System.Collections.Generic;
using System.Linq;

namespace LordLyngLib.Core.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<IndexedItem<T>> WithIndex<T> (this IEnumerable<T> enumerable)
        {
            return enumerable.Select ((item, index) => new IndexedItem<T>
            {
                Index = index,
                Value = item
            });
        }

        public static bool IsNullOrEmpty<T> (this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any ();
        }

        public static bool NotNullOrEmpty<T> (this IEnumerable<T> enumerable)
        {
            return enumerable != null && enumerable.Any ();
        }
    }
}
