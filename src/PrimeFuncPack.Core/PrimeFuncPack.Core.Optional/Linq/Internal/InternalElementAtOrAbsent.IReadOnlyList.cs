#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalElementAtOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            in int index)
            =>
            (index >= 0 && index < source.Count) switch
            {
                true => Optional.Present(source[index]),
                _ => default
            };

        public static Optional<TSource> InternalElementAtOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            in long index)
            =>
            unchecked((int)index) switch
            {
                var indexShortened when indexShortened == index
                =>
                source.InternalElementAtOrAbsent(indexShortened),

                _ => default
            };
    }
}
