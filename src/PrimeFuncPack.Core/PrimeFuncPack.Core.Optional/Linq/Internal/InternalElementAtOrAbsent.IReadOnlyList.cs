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
            index switch
            {
                _ when index >= 0 && index < source.Count
                =>
                Optional.Present(source[index]),

                _ => default
            };

        public static Optional<TSource> InternalElementAtOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            in long index)
            =>
            index switch
            {
                _ when index >= 0 && index < source.Count
                =>
                Optional.Present(source[(int)index]),

                _ => default
            };
    }
}
