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
            dictionary.TryGetValue(key, out var value) ? new(value) : default,

            IDictionary<TKey, TValue> dictionary
            =>
            dictionary.TryGetValue(key, out var value) ? new(value) : default,

            _ =>
            pairs.InnerFirstOrAbsent(
                pair => EqualityComparer<TKey>.Default.Equals(pair.Key, key))
            .Map(
                pair => pair.Value)
        };
}
