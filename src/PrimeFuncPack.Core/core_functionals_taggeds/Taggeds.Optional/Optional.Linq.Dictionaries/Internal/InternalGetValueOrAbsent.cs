#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalDictionariesExtensions
    {
        public static Optional<TValue> InternalGetValueOrAbsent<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> dictionary,
            TKey key,
            in Func<Exception> moreThanOneMatchExceptionFactory)
            =>
            dictionary
            .SingleOrAbsent(
                pair => EqualityComparer<TKey>.Default.Equals(pair.Key, key),
                moreThanOneMatchExceptionFactory)
            .Map(pair => pair.Value);
    }
}
