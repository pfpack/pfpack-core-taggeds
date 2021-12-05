using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    private static Optional<TSource> InnerElementAtOrAbsent<TSource>(
        this IList<TSource> source,
        int index)
        =>
        source.InnerElementAtOrAbsentBase(index);

    private static Optional<TSource> InnerElementAtOrAbsent<TSource>(
        this IList<TSource> source,
        long index)
        =>
        index.InnerShorten() switch
        {
            int shortened when shortened == index
            =>
            source.InnerElementAtOrAbsentBase(shortened),

            _ => default
        };

    private static Optional<TSource> InnerElementAtOrAbsentBase<TSource>(
        this IList<TSource> source,
        int index)
        =>
        index.InnerIsInRange(count: source.Count)
            ? new(source[index])
            : default;
}
