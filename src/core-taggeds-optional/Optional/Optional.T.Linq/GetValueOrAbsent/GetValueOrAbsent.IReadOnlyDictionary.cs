﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
        this IReadOnlyDictionary<TKey, TValue> dictionary,
        TKey key)
        =>
        InnerGetValueOrAbsent(
            dictionary ?? throw new ArgumentNullException(nameof(dictionary)),
            key);

    [Obsolete(InnerTryGetValueOrAbsentObsoleteMessage, error: true)]
    [DoesNotReturn]
    public static Optional<TValue> TryGetValueOrAbsent<TKey, TValue>(
        this IReadOnlyDictionary<TKey, TValue> dictionary,
        TKey key)
        =>
        throw new NotImplementedException(InnerTryGetValueOrAbsentObsoleteMessage);
}
