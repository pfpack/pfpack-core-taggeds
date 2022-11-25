using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

public sealed partial class OptionalLinqDictionariesExtensionsTest
{
    private static IEnumerable<KeyValuePair<TKey, TValue>> CreatePairsCollection<TKey, TValue>(
        params KeyValuePair<TKey, TValue>[] pairs)
    {
        foreach (var pair in pairs)
        {
            yield return pair;
        }
    }
}
