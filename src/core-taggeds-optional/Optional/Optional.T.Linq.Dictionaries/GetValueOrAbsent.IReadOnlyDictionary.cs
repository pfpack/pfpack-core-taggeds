#nullable enable

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Linq
{
    partial class OptionalLinqDictionariesExtensions
    {
        public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
            this IReadOnlyDictionary<TKey, TValue> dictionary,
            TKey key)
        {
            _ = dictionary ?? throw new ArgumentNullException(nameof(dictionary));

            return dictionary.InnerGetValueOrAbsent(key);
        }

        [Obsolete(InnerObsoleteMessages.TryGetValueOrAbsent, error: true)]
        [DoesNotReturn]
        public static Optional<TValue> TryGetValueOrAbsent<TKey, TValue>(
            this IReadOnlyDictionary<TKey, TValue> dictionary,
            TKey key)
            =>
            throw new NotImplementedException(InnerObsoleteMessages.TryGetValueOrAbsent);
    }
}
