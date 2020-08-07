#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalFirstOrAbsent<TSource>(
            this IList<TSource> source)
            =>
            source.Count switch
            {
                > 0 => Optional.Present(source[0]),
                _ => default
            };

        public static Optional<TSource> InternalFirstOrAbsent<TSource>(
            this IList<TSource> source,
            in Func<TSource, bool> predicate)
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
