using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TSource> ElementAtOrAbsent<TSource>(
        this IReadOnlyList<TSource> source,
        int index)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));

        return source.InnerElementAtOrAbsent(index);
    }

    public static Optional<TSource> ElementAtOrAbsent<TSource>(
        this IReadOnlyList<TSource> source,
        long index)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));

        return source.InnerElementAtOrAbsent(index);
    }
}
