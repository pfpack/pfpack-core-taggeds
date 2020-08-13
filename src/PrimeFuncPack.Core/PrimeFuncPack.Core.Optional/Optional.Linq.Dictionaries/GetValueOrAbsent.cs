#nullable enable

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Linq
{
    partial class DictionariesExtensions
    {
        public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> dictionary,
            in TKey key)
        {
            _ = dictionary ?? throw new ArgumentNullException(nameof(dictionary));

            return dictionary switch
            {
                IReadOnlyDictionary<TKey, TValue> dict
                =>
                dict.InternalGetValueOrAbsent(key),

                IDictionary<TKey, TValue> dict
                =>
                dict.InternalGetValueOrAbsent(key),

                var dict
                =>
                dict.InternalGetValueOrAbsent(key, CreateMoreThanOneMatchException),
            };
        }

        [Obsolete(ObsoleteMessages.TryGetValueOrAbsent, error: true)]
        [DoesNotReturn]
        public static Optional<TValue> TryGetValueOrAbsent<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> dictionary,
            in TKey key)
            =>
            throw new NotImplementedException(ObsoleteMessages.TryGetValueOrAbsent);
    }
}
