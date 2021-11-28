using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqDictionariesExtensions
{
    // TODO: Consider to use FirstOrAbsent instead of SingleOrAbsent in v2.0
    private static Optional<TValue> InnerGetValueOrAbsent<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> pairs,
        TKey key,
        Func<Exception> moreThanOneMatchExceptionFactory)
        =>
        pairs
        .SingleOrAbsent(
            pair => EqualityComparer<TKey>.Default.Equals(pair.Key, key),
            moreThanOneMatchExceptionFactory)
        .Map(pair => pair.Value);
}
