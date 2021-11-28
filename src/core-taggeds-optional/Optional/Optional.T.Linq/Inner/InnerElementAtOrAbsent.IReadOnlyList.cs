using System.Collections.Generic;

namespace System.Linq
{
    partial class OptionalLinqExtensions
    {
        private static Optional<TSource> InnerElementAtOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            int index)
            =>
            index.InnerIsInRange(count: source.Count)
                ? new(source[index])
                : default;

        private static Optional<TSource> InnerElementAtOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            long index)
            =>
            index.InnerShorten() switch
            {
                int shortened when shortened == index
                =>
                source.InnerElementAtOrAbsent(shortened),

                _ => default
            };
    }
}
