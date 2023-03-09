using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TSource> LastOrAbsent<TSource>(
        this IEnumerable<TSource> source)
        =>
        InnerLastOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)));

    public static Optional<TSource> LastOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
        =>
        InnerLastOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            predicate ?? throw new ArgumentNullException(nameof(predicate)));

    // TODO: Remove the IReadOnly-based public overloads in v3.0

    public static Optional<TSource> LastOrAbsent<TSource>(
        this IReadOnlyList<TSource> source)
        =>
        InnerLastOrAbsent_IReadOnlyList(
            source ?? throw new ArgumentNullException(nameof(source)));

    public static Optional<TSource> LastOrAbsent<TSource>(
        this IReadOnlyList<TSource> source,
        Func<TSource, bool> predicate)
        =>
        InnerLastOrAbsent_IReadOnlyList(
            source ?? throw new ArgumentNullException(nameof(source)),
            predicate ?? throw new ArgumentNullException(nameof(predicate)));
}
