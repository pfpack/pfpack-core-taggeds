using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IEnumerable<TSource> source)
        =>
        source.SingleOrAbsent(InnerCreateMoreThanOneElementException);

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<Exception> moreThanOneElementExceptionFactory)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));
        _ = moreThanOneElementExceptionFactory ?? throw new ArgumentNullException(nameof(moreThanOneElementExceptionFactory));

        return source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerSingleOrAbsent(moreThanOneElementExceptionFactory),

            IList<TSource> list
            =>
            list.InnerSingleOrAbsent(moreThanOneElementExceptionFactory),

            _ =>
            source.InnerSingleOrAbsent(moreThanOneElementExceptionFactory)
        };
    }

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
        =>
        source.SingleOrAbsent(predicate, InnerCreateMoreThanOneMatchException);

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate,
        Func<Exception> moreThanOneMatchExceptionFactory)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));
        _ = predicate ?? throw new ArgumentNullException(nameof(predicate));
        _ = moreThanOneMatchExceptionFactory ?? throw new ArgumentNullException(nameof(moreThanOneMatchExceptionFactory));

        return source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerSingleOrAbsent(predicate, moreThanOneMatchExceptionFactory),

            IList<TSource> list
            =>
            list.InnerSingleOrAbsent(predicate, moreThanOneMatchExceptionFactory),

            _ =>
            source.InnerSingleOrAbsent(predicate, moreThanOneMatchExceptionFactory)
        };
    }
}
