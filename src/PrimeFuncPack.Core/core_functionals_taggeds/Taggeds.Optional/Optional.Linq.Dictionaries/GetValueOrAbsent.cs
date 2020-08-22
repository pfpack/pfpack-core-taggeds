#nullable enable

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Linq
{
    partial class DictionariesExtensions
    {
        public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> pairs,
            in TKey key)
        {
            _ = pairs ?? throw new ArgumentNullException(nameof(pairs));

            return pairs switch
            {
                IReadOnlyDictionary<TKey, TValue> dictionary => dictionary
                .InternalGetValueOrAbsent(key),

                IDictionary<TKey, TValue> dictionary => dictionary
                .InternalGetValueOrAbsent(key),

                _ => pairs
                .InternalGetValueOrAbsent(key, CreateMoreThanOneMatchException)
            };
        }

        [Obsolete(ObsoleteMessages.TryGetValueOrAbsent, error: true)]
        [DoesNotReturn]
        public static Optional<TValue> TryGetValueOrAbsent<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> pairs,
            in TKey key)
            =>
            throw new NotImplementedException(ObsoleteMessages.TryGetValueOrAbsent);
    }
}
