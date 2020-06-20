#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class DictionariesExtensions
    {
        public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
            this IReadOnlyDictionary<TKey, TValue> dictionary,
            in TKey key)
        {
            if (dictionary is null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            return dictionary.InternalGetValueOrAbsent(key);
        }

        [Obsolete(ObsoleteMessages.TryGetValueOrAbsent, error: true)]
        public static Optional<TValue> TryGetValueOrAbsent<TKey, TValue>(
            this IReadOnlyDictionary<TKey, TValue> dictionary,
            in TKey key)
            =>
            dictionary.GetValueOrAbsent(key);
    }
}
