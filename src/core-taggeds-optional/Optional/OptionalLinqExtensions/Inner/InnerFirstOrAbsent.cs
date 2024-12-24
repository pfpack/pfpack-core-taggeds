using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
