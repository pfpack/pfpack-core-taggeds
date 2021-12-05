using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IEnumerable<TSource> source)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));

        return source.InnerSingleOrAbsentPrimary(InnerCreateMoreThanOneElementException);
    }

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<Exception> moreThanOneElementExceptionFactory)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));
        _ = moreThanOneElementExceptionFactory ?? throw new ArgumentNullException(nameof(moreThanOneElementExceptionFactory));

        return source.InnerSingleOrAbsentPrimary(moreThanOneElementExceptionFactory);
    }

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));
        _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

        return source.InnerSingleOrAbsentPrimary(predicate, InnerCreateMoreThanOneMatchException);
    }

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate,
        Func<Exception> moreThanOneMatchExceptionFactory)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));
        _ = predicate ?? throw new ArgumentNullException(nameof(predicate));
        _ = moreThanOneMatchExceptionFactory ?? throw new ArgumentNullException(nameof(moreThanOneMatchExceptionFactory));

        return source.InnerSingleOrAbsentPrimary(predicate, moreThanOneMatchExceptionFactory);
    }
}
