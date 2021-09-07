#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class OptionalLinqExtensions
    {
        private static Optional<TSource> InnerElementAtOrAbsent<TSource>(
            this IList<TSource> source,
            int index)
            =>
            index.InnerIsInRange(count: source.Count)
                ? new(source[index])
                : default;

        private static Optional<TSource> InnerElementAtOrAbsent<TSource>(
            this IList<TSource> source,
            long index)
            =>
            index.InnerShortenIndex() switch
            {
                int indexShortened when indexShortened == index
                =>
                source.InnerElementAtOrAbsent(indexShortened),

                _ => default
            };
    }
}
