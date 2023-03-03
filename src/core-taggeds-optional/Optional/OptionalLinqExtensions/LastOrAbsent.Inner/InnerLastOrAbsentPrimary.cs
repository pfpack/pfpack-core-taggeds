using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    private static Optional<TSource> InnerLastOrAbsentPrimary<TSource>(
        this IEnumerable<TSource> source)
        =>
        source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerLastOrAbsent(),

            IList<TSource> list
            =>
            list.InnerLastOrAbsent(),

            _ =>
            source.InnerLastOrAbsent()
        };

    private static Optional<TSource> InnerLastOrAbsentPrimary<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
        =>
        source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerLastOrAbsent(predicate),

            IList<TSource> list
            =>
            list.InnerLastOrAbsent(predicate),

            _ =>
            source.InnerLastOrAbsent(predicate)
        };
}
