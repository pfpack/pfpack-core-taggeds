using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    private static Optional<TSource> InnerElementAtOrAbsent_IList<TSource>(
        this IList<TSource> source,
        int index)
        =>
        InnerIsInRange(index, source.Count) ? new(source[index]) : default;

    private static Optional<TSource> InnerElementAtOrAbsent_IList<TSource>(
        this IList<TSource> source,
        long index)
    {
        var shortened = InnerShorten(index);
        return shortened == index ? source.InnerElementAtOrAbsent_IList(shortened) : default;
    }
}
