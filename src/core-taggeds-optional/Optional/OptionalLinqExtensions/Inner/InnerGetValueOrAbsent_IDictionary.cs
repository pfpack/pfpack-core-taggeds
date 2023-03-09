using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    private static Optional<TValue> InnerGetValueOrAbsent_IDictionary<TKey, TValue>(
        this IDictionary<TKey, TValue> dictionary,
        TKey key)
        =>
        dictionary.TryGetValue(key, out var value) ? new(value) : default;
}
