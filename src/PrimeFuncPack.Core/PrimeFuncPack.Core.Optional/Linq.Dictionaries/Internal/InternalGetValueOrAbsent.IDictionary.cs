#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalDictionariesExtensions
    {
        public static Optional<TValue> InternalGetValueOrAbsent<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            in TKey key)
            =>
            dictionary.TryGetValue(key, out var value) switch
            {
                true => Optional.Present(value),
                _ => default
            };
    }
}
