using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PrimeFuncPack.Core.Tests;

internal sealed class StubReadOnlyDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
    where TKey : notnull
{
    private readonly IReadOnlyDictionary<TKey, TValue> source;

    public StubReadOnlyDictionary(IReadOnlyDictionary<TKey, TValue> source)
        =>
        this.source = source;

    public TValue this[TKey key]
        =>
        source[key];

    public IEnumerable<TKey> Keys
        =>
        source.Keys;

    public IEnumerable<TValue> Values
        =>
        source.Values;

    public int Count
        =>
        source.Count;

    public bool ContainsKey(TKey key)
        =>
        source.ContainsKey(key);

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        =>
        source.GetEnumerator();

    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        =>
        source.TryGetValue(key, out value);

    IEnumerator IEnumerable.GetEnumerator()
        =>
        ((IEnumerable)source).GetEnumerator();
}