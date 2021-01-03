#nullable enable

using System.Collections.Generic;
using static System.Optional;

namespace System.Linq
{
    partial class InternalOptionalLinqExtensions
    {
        public static Optional<TSource> InternalElementAtOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            int index)
            =>
            InternalIsInRange(index, source.Count) switch
            {
                true => Present(source[index]),
                _ => default
            };

        public static Optional<TSource> InternalElementAtOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
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
