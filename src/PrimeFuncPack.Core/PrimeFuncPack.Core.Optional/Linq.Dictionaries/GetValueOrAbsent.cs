#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class DictionariesExtensions
    {
        public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> dictionary,
            in TKey key)
        {
            if (dictionary is null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

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
                dict.InternalGetValueOrAbsent(key, GetMoreThanOneMatchExceptionFactory()),
            };
        }

        [Obsolete("This method is obsolete. Call GetValueOrAbsent instead.", error: true)]
        public static Optional<TValue> TryGetValueOrAbsent<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> dictionary,
            in TKey key)
            =>
            GetValueOrAbsent(dictionary, key);
    }
}
