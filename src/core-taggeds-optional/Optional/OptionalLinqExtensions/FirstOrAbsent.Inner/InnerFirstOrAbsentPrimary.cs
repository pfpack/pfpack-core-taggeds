using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    private static Optional<TSource> InnerFirstOrAbsentPrimary<TSource>(
        this IEnumerable<TSource> source)
        =>
        source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerFirstOrAbsent(),

            IList<TSource> list
            =>
            list.InnerFirstOrAbsent(),

            _ =>
            source.InnerFirstOrAbsent()
        };

    private static Optional<TSource> InnerFirstOrAbsentPrimary<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
        =>
        source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerFirstOrAbsent(predicate),

            IList<TSource> list
            =>
            list.InnerFirstOrAbsent(predicate),

            _ =>
            source.InnerFirstOrAbsent(predicate)
        };
}
