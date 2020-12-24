#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    internal sealed class StubList<T> : IList<T>
    {
        private readonly T[] items;

        public StubList(T[] items)
            => this.items = items;

        public T this[int index]
        {
            get => items[index];
            set => throw new NotImplementedException();
        }

        public int Count
            => items.Length;

        public bool IsReadOnly
            => throw new NotImplementedException();

        public void Add(T item)
            => throw new NotImplementedException();

        public void Clear()
            => throw new NotImplementedException();

        public bool Contains(T item)
            => throw new NotImplementedException();

        public void CopyTo(T[] array, int arrayIndex)
            => throw new NotImplementedException();

        public IEnumerator<T> GetEnumerator()
            => ((IEnumerable<T>)items).GetEnumerator();

        public int IndexOf(T item)
            => throw new NotImplementedException();

        public void Insert(int index, T item)
            => throw new NotImplementedException();

        public bool Remove(T item)
            => throw new NotImplementedException();

        public void RemoveAt(int index)
            => throw new NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator()
            => items.GetEnumerator();
    }
}
