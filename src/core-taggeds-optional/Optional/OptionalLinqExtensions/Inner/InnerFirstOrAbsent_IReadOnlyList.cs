using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    private static Optional<TSource> InnerFirstOrAbsent_IReadOnlyList<TSource>(
        this IReadOnlyList<TSource> source)
        =>
        source.Count > 0 ? new(source[0]) : default;

    private static Optional<TSource> InnerFirstOrAbsent_IReadOnlyList<TSource>(
        this IReadOnlyList<TSource> source,
        Func<TSource, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            var current = source[i];

            if (predicate.Invoke(current))
            {
                return new(current);
            }
        }

        return default;
    }
}
