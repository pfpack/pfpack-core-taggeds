using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TSource> ElementAtOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        int index)
        =>
        InnerElementAtOrAbsentPrimary(
            source ?? throw new ArgumentNullException(nameof(source)),
            index);

    public static Optional<TSource> ElementAtOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        long index)
        =>
        InnerElementAtOrAbsentPrimary(
            source ?? throw new ArgumentNullException(nameof(source)),
            index);
}
