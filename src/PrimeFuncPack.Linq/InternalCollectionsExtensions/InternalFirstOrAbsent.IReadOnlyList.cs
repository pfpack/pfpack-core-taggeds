#nullable enable

using System;
using System.Collections.Generic;

namespace PrimeFuncPack
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalFirstOrAbsent<TSource>(
            this IReadOnlyList<TSource> source)
        {
            if (source.Count > 0)
            {
                return Optional.Present(source[0]);
            }

            return default;
        }

        public static Optional<TSource> InternalFirstOrAbsent<TSource>(
            this IReadOnlyList<TSource> source, in Func<TSource, bool> predicate)
        {
            for (var i = 0; i < source.Count; i++)
            {
                var item = source[i];

                if (predicate(item))
                {
                    return Optional.Present(item);
                }
            }

            return default;
        }
    }
}
