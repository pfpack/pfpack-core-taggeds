using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    private static Optional<TValue> InnerGetValueOrAbsent<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> pairs,
        TKey key)
        =>
        pairs switch
        {
            IReadOnlyDictionary<TKey, TValue> dictionary
            =>
            dictionary.InnerGetValueOrAbsent_IReadOnlyDictionary(key),

            IDictionary<TKey, TValue> dictionary
            =>
            dictionary.InnerGetValueOrAbsent_IDictionary(key),

            _ =>
            pairs.InnerGetValueOrAbsent_IEnumerable(key)
        };
}
