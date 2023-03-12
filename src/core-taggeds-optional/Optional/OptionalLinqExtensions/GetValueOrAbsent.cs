using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> pairs,
        TKey key)
        =>
        InnerGetValueOrAbsent(
            pairs ?? throw new ArgumentNullException(nameof(pairs)),
            key);

    private const string NotIntendedMessage_TryGetValueOrAbsent
        =
        "This method is not intended for use. Call GetValueOrAbsent instead.";

    [Obsolete(NotIntendedMessage_TryGetValueOrAbsent, error: true)]
    [DoesNotReturn]
    public static Optional<TValue> TryGetValueOrAbsent<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> pairs,
        TKey key)
        =>
        throw new NotImplementedException(NotIntendedMessage_TryGetValueOrAbsent);
}
