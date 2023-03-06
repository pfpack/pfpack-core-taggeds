using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IEnumerable<TSource> source)
        =>
        InnerSingleOrAbsentPrimary(
            source ?? throw new ArgumentNullException(nameof(source)),
            InnerCreateMoreThanOneElementException);

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<Exception> moreThanOneElementExceptionFactory)
        =>
        InnerSingleOrAbsentPrimary(
            source ?? throw new ArgumentNullException(nameof(source)),
            moreThanOneElementExceptionFactory ?? throw new ArgumentNullException(nameof(moreThanOneElementExceptionFactory)));

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
        =>
        InnerSingleOrAbsentPrimary(
            source ?? throw new ArgumentNullException(nameof(source)),
            predicate ?? throw new ArgumentNullException(nameof(predicate)),
            InnerCreateMoreThanOneMatchException);

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate,
        Func<Exception> moreThanOneMatchExceptionFactory)
        =>
        InnerSingleOrAbsentPrimary(
            source ?? throw new ArgumentNullException(nameof(source)),
            predicate ?? throw new ArgumentNullException(nameof(predicate)),
            moreThanOneMatchExceptionFactory ?? throw new ArgumentNullException(nameof(moreThanOneMatchExceptionFactory)));
}
