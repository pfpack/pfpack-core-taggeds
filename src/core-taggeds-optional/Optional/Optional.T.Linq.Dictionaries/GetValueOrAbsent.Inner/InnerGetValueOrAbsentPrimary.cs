using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqDictionariesExtensions
{
    private static Optional<TValue> InnerGetValueOrAbsentPrimary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> pairs,
        TKey key)
        =>
        pairs switch
        {
            IReadOnlyDictionary<TKey, TValue> dictionary
            =>
            dictionary.InnerGetValueOrAbsent(key),

            IDictionary<TKey, TValue> dictionary
            =>
            dictionary.InnerGetValueOrAbsent(key),

            _ =>
            pairs.InnerGetValueOrAbsent(key)
        };
}
