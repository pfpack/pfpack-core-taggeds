using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IEnumerable<TSource> source)
        =>
        InnerSingleOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            InnerCreateMoreThanOneElementException);

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<Exception> moreThanOneElementExceptionFactory)
        =>
        InnerSingleOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            moreThanOneElementExceptionFactory ?? throw new ArgumentNullException(nameof(moreThanOneElementExceptionFactory)));

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
        =>
        InnerSingleOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            predicate ?? throw new ArgumentNullException(nameof(predicate)),
            InnerCreateMoreThanOneMatchException);

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate,
        Func<Exception> moreThanOneMatchExceptionFactory)
        =>
        InnerSingleOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            predicate ?? throw new ArgumentNullException(nameof(predicate)),
            moreThanOneMatchExceptionFactory ?? throw new ArgumentNullException(nameof(moreThanOneMatchExceptionFactory)));

    // TODO: Remove the IReadOnly-based public overloads in v3.0

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IReadOnlyList<TSource> source)
        =>
        InnerSingleOrAbsent_IReadOnlyList(
            source ?? throw new ArgumentNullException(nameof(source)),
            InnerCreateMoreThanOneElementException);

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IReadOnlyList<TSource> source,
        Func<Exception> moreThanOneElementExceptionFactory)
        =>
        InnerSingleOrAbsent_IReadOnlyList(
            source ?? throw new ArgumentNullException(nameof(source)),
            moreThanOneElementExceptionFactory ?? throw new ArgumentNullException(nameof(moreThanOneElementExceptionFactory)));

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IReadOnlyList<TSource> source,
        Func<TSource, bool> predicate)
        =>
        InnerSingleOrAbsent_IReadOnlyList(
            source ?? throw new ArgumentNullException(nameof(source)),
            predicate ?? throw new ArgumentNullException(nameof(predicate)),
            InnerCreateMoreThanOneMatchException);

    public static Optional<TSource> SingleOrAbsent<TSource>(
        this IReadOnlyList<TSource> source,
        Func<TSource, bool> predicate,
        Func<Exception> moreThanOneMatchExceptionFactory)
        =>
        InnerSingleOrAbsent_IReadOnlyList(
            source ?? throw new ArgumentNullException(nameof(source)),
            predicate ?? throw new ArgumentNullException(nameof(predicate)),
            moreThanOneMatchExceptionFactory ?? throw new ArgumentNullException(nameof(moreThanOneMatchExceptionFactory)));
}
