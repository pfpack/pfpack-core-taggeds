using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    private static Optional<TSource> InnerElementAtOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Index index)
        =>
        index.IsFromEnd is not true
        ? source.InnerElementAtOrAbsent(index.Value)
        : source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerElementAtOrAbsent_IReadOnlyList(list.Count - index.Value),

            IList<TSource> list
            =>
            list.InnerElementAtOrAbsent_IList(list.Count - index.Value),

            _ =>
            source.InnerElementAtOrAbsent_IEnumerable_FromEnd(index.Value)
        };

    private static Optional<TSource> InnerElementAtOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        int index)
        =>
        source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerElementAtOrAbsent_IReadOnlyList(index),

            IList<TSource> list
            =>
            list.InnerElementAtOrAbsent_IList(index),

            _ =>
            source.InnerElementAtOrAbsent_IEnumerable(index)
        };

    private static Optional<TSource> InnerElementAtOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        long index)
        =>
        source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerElementAtOrAbsent_IReadOnlyList(index),

            IList<TSource> list
            =>
            list.InnerElementAtOrAbsent_IList(index),

            _ =>
            source.InnerElementAtOrAbsent_IEnumerable(index)
        };
}
