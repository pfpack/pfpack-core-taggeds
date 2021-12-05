using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqDictionariesExtensions
{
    private static Optional<TValue> InnerGetValueOrAbsent<TKey, TValue>(
        this IReadOnlyDictionary<TKey, TValue> dictionary,
        TKey key)
        =>
        dictionary.TryGetValue(key, out var value)
            ? new(value)
            : default;
}
