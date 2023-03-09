using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    private static Optional<TSource> InnerFirstOrAbsent<TSource>(
        this IEnumerable<TSource> source)
        =>
        source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerFirstOrAbsent_IReadOnlyList(),

            IList<TSource> list
            =>
            list.InnerFirstOrAbsent_IList(),

            _ =>
            source.InnerFirstOrAbsent_IEnumerable()
        };

    private static Optional<TSource> InnerFirstOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
        =>
        source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerFirstOrAbsent_IReadOnlyList(predicate),

            IList<TSource> list
            =>
            list.InnerFirstOrAbsent_IList(predicate),

            _ =>
            source.InnerFirstOrAbsent_IEnumerable(predicate)
        };
}
