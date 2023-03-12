using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

public sealed partial class OptionalLinqExtensionsTests
{
    private static IReadOnlyList<T> CreateReadOnlyList<T>(
        params T[] items)
        =>
        new StubReadOnlyList<T>(items);

    private static IList<T> CreateList<T>(
        params T[] items)
        =>
        new StubList<T>(items);

    private static IEnumerable<T> CreateCollection<T>(
        params T[] items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    private static IEnumerable<KeyValuePair<TKey, TValue>> CreatePairCollection<TKey, TValue>(
        params KeyValuePair<TKey, TValue>[] pairs)
    {
        foreach (var pair in pairs)
        {
            yield return pair;
        }
    }

    private static SomeException CreateSomeException()
        =>
        new();
}
