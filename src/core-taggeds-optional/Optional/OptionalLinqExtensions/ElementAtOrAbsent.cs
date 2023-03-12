using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TSource> ElementAtOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        int index)
        =>
        InnerElementAtOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            index);

    public static Optional<TSource> ElementAtOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        long index)
        =>
        InnerElementAtOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            index);
}
