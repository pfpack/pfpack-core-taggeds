using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    private static Optional<TSource> InnerElementAtOrAbsent_IReadOnlyList<TSource>(
        this IReadOnlyList<TSource> source,
        int index)
        =>
        index >= 0 && index < source.Count ? new(source[index]) : default;
}
