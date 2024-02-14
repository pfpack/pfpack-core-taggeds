using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

[Obsolete("These cases test obsolete class 'OptionalLinqDictionariesExtensions'.")]
public sealed partial class ObsoleteOptionalLinqDictionariesExtensionsTests
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
