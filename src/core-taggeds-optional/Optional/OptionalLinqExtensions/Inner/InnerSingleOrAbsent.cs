using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    private static Optional<TSource> InnerSingleOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<Exception> moreThanOneElementExceptionFactory)
        =>
        source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerSingleOrAbsent_IReadOnlyList(moreThanOneElementExceptionFactory),

            IList<TSource> list
            =>
            list.InnerSingleOrAbsent_IList(moreThanOneElementExceptionFactory),

            _ =>
            source.InnerSingleOrAbsent_IEnumerable(moreThanOneElementExceptionFactory)
        };

    private static Optional<TSource> InnerSingleOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate,
        Func<Exception> moreThanOneMatchExceptionFactory)
        =>
        source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerSingleOrAbsent_IReadOnlyList(predicate, moreThanOneMatchExceptionFactory),

            IList<TSource> list
            =>
            list.InnerSingleOrAbsent_IList(predicate, moreThanOneMatchExceptionFactory),

            _ =>
            source.InnerSingleOrAbsent_IEnumerable(predicate, moreThanOneMatchExceptionFactory)
        };
}
