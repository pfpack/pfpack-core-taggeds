using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqDictionariesExtensions
{
    private static Optional<TValue> InnerGetValueOrAbsent<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> pairs,
        TKey key)
        =>
        // TODO: Call InnerFirstOrAbsentPrimary instead of FirstOrAbsent
        pairs.FirstOrAbsent(
            pair => EqualityComparer<TKey>.Default.Equals(pair.Key, key))
        .Map(
            pair => pair.Value);
}
