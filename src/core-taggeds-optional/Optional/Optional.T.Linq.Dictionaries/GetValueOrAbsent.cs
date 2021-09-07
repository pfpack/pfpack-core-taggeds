#nullable enable

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Linq
{
    partial class OptionalLinqDictionariesExtensions
    {
        public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> pairs,
            TKey key)
        {
            _ = pairs ?? throw new ArgumentNullException(nameof(pairs));

            return pairs switch
            {
                IReadOnlyDictionary<TKey, TValue> dictionary => dictionary
                .InnerGetValueOrAbsent(key),

                IDictionary<TKey, TValue> dictionary => dictionary
                .InnerGetValueOrAbsent(key),

                _ => pairs
                .InnerGetValueOrAbsent(key, InnerCreateMoreThanOneMatchException)
            };
        }

        [Obsolete(InnerObsoleteMessages.TryGetValueOrAbsent, error: true)]
        [DoesNotReturn]
        public static Optional<TValue> TryGetValueOrAbsent<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> pairs,
            TKey key)
            =>
            throw new NotImplementedException(InnerObsoleteMessages.TryGetValueOrAbsent);
    }
}
