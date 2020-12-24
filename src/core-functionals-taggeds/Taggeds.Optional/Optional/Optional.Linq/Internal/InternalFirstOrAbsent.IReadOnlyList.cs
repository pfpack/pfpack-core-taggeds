#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalFirstOrAbsent<TSource>(
            this IReadOnlyList<TSource> source)
            =>
            source.Count switch
            {
                > 0 => Optional.Present(source[0]),
                _ => default
            };

        public static Optional<TSource> InternalFirstOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            Func<TSource, bool> predicate)
        {
            for (var i = 0; i < source.Count; i++)
            {
                var current = source[i];

                if (predicate.Invoke(current))
                {
                    return Optional.Present(current);
                }
            }

            return default;
        }
    }
}
