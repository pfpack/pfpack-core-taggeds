#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalDictionariesExtensions
    {
        public static Optional<TValue> InternalGetValueOrAbsent<TKey, TValue>(
            this IReadOnlyDictionary<TKey, TValue> dictionary,
            TKey key)
            =>
            dictionary.TryGetValue(key, out var value) switch
            {
                true => Optional<TValue>.Present(value),
                _ => default
            };
    }
}
