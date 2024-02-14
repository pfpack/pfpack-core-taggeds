using System.Collections;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

internal sealed class StubReadOnlyList<T> : IReadOnlyList<T>
{
    private readonly T[] items;

    public StubReadOnlyList(T[] items)
        => this.items = items;

    public T this[int index]
        => items[index];

    public int Count
        => items.Length;

    public IEnumerator<T> GetEnumerator()
        => ((IEnumerable<T>)items).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => items.GetEnumerator();
}
