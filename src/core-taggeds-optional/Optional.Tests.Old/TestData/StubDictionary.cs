using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PrimeFuncPack.Core.Tests;

internal sealed class StubDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    where TKey : notnull
{
    private readonly IDictionary<TKey, TValue> source = new Dictionary<TKey, TValue>();

    public TValue this[TKey key]
    {
        get => source[key];
        set => source[key] = value;
    }

    public ICollection<TKey> Keys => source.Keys;

    public ICollection<TValue> Values => source.Values;

    public int Count => source.Count;

    public bool IsReadOnly => source.IsReadOnly;

    public void Add(TKey key, TValue value)
        =>
        source.Add(key, value);

    public void Add(KeyValuePair<TKey, TValue> item)
        =>
        source.Add(item);

    public void Clear()
        =>
        source.Clear();

    public bool Contains(KeyValuePair<TKey, TValue> item)
        =>
        source.Contains(item);

    public bool ContainsKey(TKey key)
        =>
        source.ContainsKey(key);

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        =>
        source.CopyTo(array, arrayIndex);

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        =>
        source.GetEnumerator();

    public bool Remove(TKey key)
        =>
        source.Remove(key);

    public bool Remove(KeyValuePair<TKey, TValue> item)
        =>
        source.Remove(item);

    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        =>
        source.TryGetValue(key, out value);

    IEnumerator IEnumerable.GetEnumerator()
        =>
        ((IEnumerable)source).GetEnumerator();
}