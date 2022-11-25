using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

[Obsolete("These cases test an obsolete class")]
public sealed partial class OptionalLinqDictionariesExtensionsObsoleteTest
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
