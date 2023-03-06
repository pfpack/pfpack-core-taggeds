using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    private static Optional<TValue> InnerGetValueOrAbsent<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> pairs,
        TKey key)
        =>
        pairs.InnerFirstOrAbsentPrimary(
            pair => EqualityComparer<TKey>.Default.Equals(pair.Key, key))
        .Map(
            pair => pair.Value);
}
