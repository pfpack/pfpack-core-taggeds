﻿using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IReadOnlyList<TSource> source)
        =>
        source.SingleOrAbsent(InnerCreateMoreThanOneElementException);

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IReadOnlyList<TSource> source,
        Func<Exception> moreThanOneElementExceptionFactory)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));
        _ = moreThanOneElementExceptionFactory ?? throw new ArgumentNullException(nameof(moreThanOneElementExceptionFactory));

        return source.InnerSingleOrAbsent(moreThanOneElementExceptionFactory);
    }

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IReadOnlyList<TSource> source,
        Func<TSource, bool> predicate)
        =>
        source.SingleOrAbsent(predicate, InnerCreateMoreThanOneMatchException);

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IReadOnlyList<TSource> source,
        Func<TSource, bool> predicate,
        Func<Exception> moreThanOneMatchExceptionFactory)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));
        _ = predicate ?? throw new ArgumentNullException(nameof(predicate));
        _ = moreThanOneMatchExceptionFactory ?? throw new ArgumentNullException(nameof(moreThanOneMatchExceptionFactory));

        return source.InnerSingleOrAbsent(predicate, moreThanOneMatchExceptionFactory);
    }
}
