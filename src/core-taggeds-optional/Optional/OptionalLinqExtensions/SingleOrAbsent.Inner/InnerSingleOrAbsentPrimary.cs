using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    private static Optional<TSource> InnerSingleOrAbsentPrimary<TSource>(
        this IEnumerable<TSource> source,
        Func<Exception> moreThanOneElementExceptionFactory)
        =>
        source switch
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

    private static Optional<TSource> InnerSingleOrAbsentPrimary<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate,
        Func<Exception> moreThanOneMatchExceptionFactory)
        =>
        source switch
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
