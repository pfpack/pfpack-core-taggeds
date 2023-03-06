using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    private static Optional<TSource> InnerElementAtOrAbsentPrimary<TSource>(
        this IEnumerable<TSource> source,
        int index)
        =>
        source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerElementAtOrAbsent(index),

            IList<TSource> list
            =>
            list.InnerElementAtOrAbsent(index),

            _ =>
            source.InnerElementAtOrAbsent(index)
        };

    private static Optional<TSource> InnerElementAtOrAbsentPrimary<TSource>(
        this IEnumerable<TSource> source,
        long index)
        =>
        source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerElementAtOrAbsent(index),

            IList<TSource> list
            =>
            list.InnerElementAtOrAbsent(index),

            _ =>
            source.InnerElementAtOrAbsent(index)
        };
}
