using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> pairs,
        TKey key)
        =>
        InnerGetValueOrAbsentPrimary(
            pairs ?? throw new ArgumentNullException(nameof(pairs)),
            key);

    [Obsolete(InnerTryGetValueOrAbsentObsoleteMessage, error: true)]
    [DoesNotReturn]
    public static Optional<TValue> TryGetValueOrAbsent<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> pairs,
        TKey key)
        =>
        throw new NotImplementedException(InnerTryGetValueOrAbsentObsoleteMessage);
}
