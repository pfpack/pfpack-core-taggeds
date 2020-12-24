#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalElementAtOrAbsent<TSource>(
            this IList<TSource> source,
            int index)
            =>
            InternalIsInRange(index, source.Count) switch
            {
                true => Optional.Present(source[index]),
                _ => default
            };

        public static Optional<TSource> InternalElementAtOrAbsent<TSource>(
            this IList<TSource> source,
            long index)
            =>
            InternalShortenIndex(index) switch
            {
                int indexShortened when indexShortened == index
                =>
                source.InternalElementAtOrAbsent(indexShortened),

                _ => default
            };
    }
}
