#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalDictionariesExtensions
    {
        public static Optional<TValue> InternalGetValueOrAbsent<TKey, TValue>(
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
}
