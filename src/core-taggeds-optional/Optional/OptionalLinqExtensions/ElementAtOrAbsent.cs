using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TSource> ElementAtOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        int index)
        =>
        InnerElementAtOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            index);

    public static Optional<TSource> ElementAtOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        long index)
        =>
        InnerElementAtOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            index);

    // TODO: Remove the IReadOnly-based public overloads in v3.0

    public static Optional<TSource> ElementAtOrAbsent<TSource>(
        this IReadOnlyList<TSource> source,
        int index)
        =>
        InnerElementAtOrAbsent_IReadOnlyList(
            source ?? throw new ArgumentNullException(nameof(source)),
            index);

    public static Optional<TSource> ElementAtOrAbsent<TSource>(
        this IReadOnlyList<TSource> source,
        long index)
        =>
        InnerElementAtOrAbsent_IReadOnlyList(
            source ?? throw new ArgumentNullException(nameof(source)),
            index);
}
