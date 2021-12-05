using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> pairs,
        TKey key)
    {
        _ = pairs ?? throw new ArgumentNullException(nameof(pairs));

        return pairs.InnerGetValueOrAbsentPrimary(key);
    }

    [Obsolete(InnerTryGetValueOrAbsentObsoleteMessage, error: true)]
    [DoesNotReturn]
    public static Optional<TValue> TryGetValueOrAbsent<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> pairs,
        TKey key)
        =>
        throw new NotImplementedException(InnerTryGetValueOrAbsentObsoleteMessage);
}
