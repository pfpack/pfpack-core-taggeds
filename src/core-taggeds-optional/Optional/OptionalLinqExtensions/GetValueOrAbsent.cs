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

    [Obsolete(InnerTryGetValueOrAbsentNotIntendedMessage, error: true)]
    [DoesNotReturn]
    public static Optional<TValue> TryGetValueOrAbsent<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> pairs,
        TKey key)
        =>
        throw new NotImplementedException(InnerTryGetValueOrAbsentNotIntendedMessage);

    // TODO: Remove the IReadOnly-based public overloads in v3.0

    public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
        this IReadOnlyDictionary<TKey, TValue> dictionary,
        TKey key)
        =>
        InnerGetValueOrAbsent_IReadOnlyDictionary(
            dictionary ?? throw new ArgumentNullException(nameof(dictionary)),
            key);

    [Obsolete(InnerTryGetValueOrAbsentNotIntendedMessage, error: true)]
    [DoesNotReturn]
    public static Optional<TValue> TryGetValueOrAbsent<TKey, TValue>(
        this IReadOnlyDictionary<TKey, TValue> dictionary,
        TKey key)
        =>
        throw new NotImplementedException(InnerTryGetValueOrAbsentNotIntendedMessage);
}
