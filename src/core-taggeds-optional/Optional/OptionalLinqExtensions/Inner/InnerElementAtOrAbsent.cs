using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Optional<TSource> InnerElementAtOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Index index)
        =>
        source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerElementAtOrAbsent_IReadOnlyList(index.GetOffset(list.Count)),

            IList<TSource> list
            =>
            list.InnerElementAtOrAbsent_IList(index.GetOffset(list.Count)),

            _ => index.IsFromEnd is false
            ? source.InnerElementAtOrAbsent_IEnumerable(index.Value)
            : source.InnerElementAtOrAbsent_IEnumerable_FromEnd(index.Value)
        };

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
}
