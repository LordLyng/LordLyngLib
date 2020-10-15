using System;

namespace LordLyngLib
{
    public struct IndexedItem<T>
    {
        public T Value { get; set; }
        public int Index { get; set; }

        public void Deconstruct(out int index, out T value) => (index, value) = (Index, Value);
    }
}
